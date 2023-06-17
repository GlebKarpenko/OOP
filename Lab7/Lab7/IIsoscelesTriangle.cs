using System;

namespace Lab7
{
    public interface IIsoscelesTriangle
    {
        double side { set; get; }
        double baseSide { get; set; }
        void printPerimeter();
        void calculateArea();
        void calculateInnerRadius();
        void calculateOuterRadius();
        void printAllMembers();
    }
}
