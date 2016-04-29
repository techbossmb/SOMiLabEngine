using System;
using System.Configuration;
using System.Timers;


namespace CVE_ExperimentEngine
{
    class Program
    {
        private Timer pollingTimer;
        private ExperimentQueue experimentQueue;
        private ExperimentExecutor experimentExecutor;
        private Timer t;
        private LabVIEWTool lv;
        private int expID;
        private int selected;
        private Program()
        {
            this.pollingTimer = new Timer(EngineConfiguration.pollingInterval);
            this.pollingTimer.Enabled = false;
            this.pollingTimer.Elapsed += new ElapsedEventHandler(timerElapsedHandler);
            this.experimentQueue = new ExperimentQueue(EngineConfiguration.connectionString);
            this.experimentExecutor = new ExperimentExecutor();
            
        }
        void t_Elapsed(Object source, ElapsedEventArgs args)
        {
            t.Stop();
            Notification.writeMessage("\tnow stopping actuator");
            lv.callDll(3, 200);
            Notification.writeMessage("Finished running Experiment: "+ expID);// + experiment.experimentID);
        }
        void timerElapsedHandler(Object source, ElapsedEventArgs args)
        {
            //pause! thou timer
            this.pollingTimer.Stop();
            try
            {
                if (this.experimentQueue.isExperimentWaiting())
                {
                    Experiment experiment = this.experimentQueue.loadNextExperiment();
                    Notification.writeMessage("\nLoaded Experiment: " + experiment.experimentID);
                    string experimentResult = this.experimentExecutor.executeExperiment(experiment);
                    this.experimentQueue.completeExperiment(experimentResult, experiment.experimentID);
                    selected = experimentExecutor.labSelect;
                    if (selected == 2)
                    {
                        t = new Timer(60000);
                        lv = new LabVIEWTool();
                        expID = experiment.experimentID;

                        Console.WriteLine("\tnow retracting actuator");
                        lv.callDll(2, 200);

                        t.Elapsed += new ElapsedEventHandler(t_Elapsed);
                        t.Start();
                    }
                    else if (selected == 1)
                    {
                        Notification.writeMessage("Finished running Experiment: " + expID);
                    }
                    
                }
            }
            catch (Exception ex) { 
                Notification.writeError("Error while trying to run Experiment: " + ex.StackTrace);
            }            
            //"continue! thou timer
            this.pollingTimer.Start();    
            
        }

        private void start()
        {
            this.pollingTimer.Start();
        }

        private void stop()
        {
            this.pollingTimer.Stop();
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.start();
            string command = "";
            while(true){
                command = Console.In.ReadLine();
                Console.Out.WriteLine( "'" + command + "' Is an unrecognized command"); 
            }
        }

    }
}
