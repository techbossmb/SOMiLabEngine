﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4016
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=2.0.50727.1432.
// 
namespace CVE_ExperimentEngine {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ilab.oauife.edu.ng/CVE")]
    [System.Xml.Serialization.XmlRootAttribute("Experiment", Namespace="http://ilab.oauife.edu.ng/CVE", IsNullable=false)]
    public partial class CVE_Experiment {
        
        private double loadField;
        
        private double pointField;
        
        private double lengthField;
        
        private double modulusField;
        
        private double inertiaField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double load {
            get {
                return this.loadField;
            }
            set {
                this.loadField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double point {
            get {
                return this.pointField;
            }
            set {
                this.pointField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double length {
            get {
                return this.lengthField;
            }
            set {
                this.lengthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double modulus {
            get {
                return this.modulusField;
            }
            set {
                this.modulusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double inertia {
            get {
                return this.inertiaField;
            }
            set {
                this.inertiaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ilab.oauife.edu.ng/CVE")]
    [System.Xml.Serialization.XmlRootAttribute("Result", Namespace="http://ilab.oauife.edu.ng/CVE", IsNullable=false)]
    public partial class CVE_ExperimentResult {
        
        private double deflectionField;
        
        private double [] spointsField;

        private long experimentIDField;
        
        private double [] bpointsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double deflection {
            get {
                return this.deflectionField;
            }
            set {
                this.deflectionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double [] spoints {
            get {
                return this.spointsField;
            }
            set {
                this.spointsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long experimentID
        {
            get
            {
                return this.experimentIDField;
            }
            set
            {
                this.experimentIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double [] bpoints {
            get {
                return this.bpointsField;
            }
            set {
                this.bpointsField = value;
            }
        }
    }
}