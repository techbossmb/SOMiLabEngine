# SOMiLabEngine
Strength of Materials iLab Experiment Engine

Server engine of the Strength of Materials iLab. This program polls an MSSQL database for new experiment submission and loads the experiment specification as soon as it is available. 
Once loaded, it extracts the fields in the experiment specification using the XML schema document as guide.
The extrracted specification is forwarded (using dynamic linked libraries created from LabVIEW) to the hardware experimental setup (automated control system) that performs the experiment.
Once done, the result is sent to database for onward delivery to the client that sent the specification.

The hardware setup can be found here: http://techbossmb.com/projects.php?p=somilab

Note: I wrote this code in 2011 and I haven't updated it since then.
