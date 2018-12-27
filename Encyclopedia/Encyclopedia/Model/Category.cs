﻿using System;

namespace Encyclopedia.Model
{
    class Category
    {
        // fields
        private int id;
        private String name;

        // constructor
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // setters and getters
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public String Name
        {
            get
            {
                return name;
            }
            set
            {
				name = value ?? throw new ArgumentNullException(nameof(name));
			}
        }

        // overrided ToString
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
