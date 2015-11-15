using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Xml.Serialization;


namespace CVE_ExperimentEngine
{
    class ExperimentExecutor
    {
        private CVE_Experiment currentExperiment;
        private CVE_ExperimentResult currentExpResult;
        private CVE_experimentengine expEngine;
        public int labSelect;
        public ExperimentExecutor() { }
       
        private string serializeLabResult(CVE_ExperimentResult labResult)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                StringWriter writer = new StringWriter(stringBuilder);
                XmlSerializer serializer = new XmlSerializer(typeof(CVE_ExperimentResult));
                serializer.Serialize(writer, labResult);
                writer.Flush();
                writer.Close();
                String result = stringBuilder.ToString();
                return result;
            }
            catch (Exception ex)
            {
                Notification.writeError("Error serializing lab result\n" + ex.StackTrace);
            }
            return null;
        }     
        
        public String executeExperiment(Experiment experiment)
        {
            currentExpResult = new CVE_ExperimentResult();
            
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(CVE_Experiment));
                StringReader stringReader = new StringReader(experiment.experimentSpecification);
                currentExperiment = (CVE_Experiment)serializer.Deserialize(stringReader);
                Console.WriteLine("Extracted Experimented Specification.\nApplied Load = " + currentExperiment.load);
            }
            catch(Exception ex){
                Notification.writeError("Failed to deserialize lab project: " + ex.StackTrace);
                return this.serializeLabResult(currentExpResult);
            }
            expEngine = new CVE_experimentengine();
            currentExpResult.experimentID = experiment.experimentID;
            if (currentExperiment.length != 0)
            {
                labSelect = 1;
                Console.WriteLine("Your Experiment is being simulated");
                currentExpResult.spoints = this.expEngine.shearforcepoints(currentExperiment.load, currentExperiment.point, currentExperiment.length);
                currentExpResult.bpoints = this.expEngine.bendingmdpoints(currentExperiment.load, currentExperiment.point, currentExperiment.length);
                currentExpResult.deflection = this.expEngine.maximumdeflection(currentExperiment.load, currentExperiment.length, currentExperiment.modulus, currentExperiment.inertia);
                Console.WriteLine("Deflection = " + currentExpResult.deflection);
            }
            else
            {
                labSelect = 2;
                //at this point, we call the labVIEW dll to execute the experiment
                LabVIEWTool lv = new LabVIEWTool();
                Console.WriteLine("LabVIEW dll has been successfully called");
                Console.WriteLine("\tnow extending actuator");
                //apply the load and read deflection
                /*arg 1 = 1- extend actuator to apply load and also read deflection
                 *arg 1 = 2- retract actuator to stop applying load and prepare for next, then stop afterward
                 *arg 1 = 3 stop!
                 */
                currentExpResult.deflection = lv.callDll(1, currentExperiment.load);
                Console.WriteLine("Deflection = "+currentExpResult.deflection);
            }
                       
            return this.serializeLabResult(currentExpResult);
        }
    }
}