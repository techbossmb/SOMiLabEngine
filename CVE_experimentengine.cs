using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CVE_ExperimentEngine
{
   
public class CVE_experimentengine {
    
    public CVE_experimentengine(){}

   
    public double [] shearforcepoints(double load,double point,double length){
    double x = point;
    double l =length;
    double p= load;
    double Rb= p*x/l;
    double Ra = p -Rb;
    double [] points  = {0.0,Ra,x,Ra,x,p,l,p,l,0.0};
            return points;
    }

    
    public double[] bendingmdpoints(double load,double point,double length){
    double x = point;
    double l =length;
    double p= load;
    double Mmax= p*x;
    double [] points ={0,0,x,p,l,0};
    return points;
    }
    
   
    public double maximumdeflection(double load,double length,double modulus,double inertia){
    double p = load,
           l =length,
           e = modulus,
            i = inertia;    
    double ymax = (p*Math.Pow(l,3.0))/(48*e*i);
    return ymax;
    }
}
 

}
