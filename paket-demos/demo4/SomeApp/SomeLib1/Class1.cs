﻿using Newtonsoft.Json;

namespace SomeLib1
{
    public class Class1
    {
        public void Foo()
        {
            var customer = new Customer { Name = "Homer" };
            var result = JsonConvert.SerializeObject(customer);
        }
    }

    public class Customer
    {
        public string Name { get; set; }
    }
}