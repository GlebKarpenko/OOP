using System;

namespace Lab7
{
    public interface IScaleneTriangle
    {
        double side1 { set; get; }
        double side2 { get; set; }
        double side3 { get; set; }
        void printPerimeter();
        void calculateArea();
        void calculateInnerRadius();
        void calculateOuterRadius();
        void printAllMembers();
    }
}
