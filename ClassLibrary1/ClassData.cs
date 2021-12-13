using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;


namespace Solution3
{
    public class ClassData
    {
        public string Name { get; }
        public ObservableCollection<ClassMemberData> Members { get; set; }
        public ClassData(string name)
        {
            Name = name;
            Members = new ObservableCollection<ClassMemberData> 
            { 
                new ClassMemberData("Fields"), new ClassMemberData("Properties"), new ClassMemberData("Methods")
            };
        }
    }
}