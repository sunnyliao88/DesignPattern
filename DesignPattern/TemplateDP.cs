using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    public class TemplateDP
    {
        public static void Demo()
        {
            new BuildWoolHouse();
            new BuildConcreteHouse();
        }
    }

    public abstract class BuildHouseTemplate
    {
        public BuildHouseTemplate()
        {
            BuildFoundation();
            BuildPillars();
            BuildWalls();
            BuildWindows();
        }

        protected virtual void BuildFoundation()
        {
            Console.WriteLine($"Build house foundation");
        }
        protected abstract void BuildPillars();
        protected abstract void BuildWalls();
        protected abstract void BuildWindows();
    }

    public class BuildWoolHouse : BuildHouseTemplate
    {
        public BuildWoolHouse()
        {
        }

        protected override void BuildPillars()
        {
            Console.WriteLine($"Build woolHouse pillars");
        }

        protected override void BuildWalls()
        {
            Console.WriteLine($"Build woolHouse walls");
        }

        protected override void BuildWindows()
        {
            Console.WriteLine($"Build woolHouse windows");
        }
    }
    public class BuildConcreteHouse : BuildHouseTemplate
    {
        public BuildConcreteHouse()
        {
        }

        protected override void BuildPillars()
        {
            Console.WriteLine($"Build ConcreteHouse pillars");
        }

        protected override void BuildWalls()
        {
            Console.WriteLine($"Build ConcreteHouse walls");
        }

        protected override void BuildWindows()
        {
            Console.WriteLine($"Build ConcreteHouse windows");
        }
    }
}
