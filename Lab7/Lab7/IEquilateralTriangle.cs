using System;

namespace Lab7
{
    public interface IEquilateralTriangle
    {
        double side { set; get; }
        void printPerimeter();
        void calculateArea();
        void calculateInnerRadius();
        void calculateOuterRadius();
        void printAllMembers();
    }
}

