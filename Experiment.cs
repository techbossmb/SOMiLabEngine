using System;
using System.Text;

namespace CVE_ExperimentEngine
{
    class Experiment
    {
        private int _experimentID;
        private string _experimentSpec;
        public Experiment()
        {
            this.experimentID = -1;
            this.experimentSpecification = "";
        }
        public Experiment(int experimentID, string experimentSpecification)
        {
            this._experimentID = experimentID;
            this._experimentSpec = experimentSpecification;
        }

        public int experimentID
        {
            get { return this._experimentID; }
            set { this._experimentID = value; }
        }

        public string experimentSpecification
        {
            get { return this._experimentSpec; }
            set { this._experimentSpec = value; }
        }
    }
}
