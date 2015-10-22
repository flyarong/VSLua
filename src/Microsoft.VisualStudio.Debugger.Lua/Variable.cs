﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.VisualStudio.Debugger.Lua
{
    public class Variable
    {
        public Variable(string name, string value, string type)
        {
            this.Name = name;
            this.Value = value;
            this.Type = type;
        }

        public string Name { get; private set; }

        public string Value { get; private set; }

        public string Type { get; private set; }

        public List<Variable> Children { get; private set; }

        public bool HasChildren()
        {
            if (this.Children == null)
                return false;
            return Children.Count > 0;
        }
        public void AddChild(Variable child)
        {
            if (Children == null)
                Children = new List<Variable>();
            Children.Add(child);
        }
    }
}
