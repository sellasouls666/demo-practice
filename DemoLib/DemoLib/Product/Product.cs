using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib.Product
{
    class Product
    {
        public string articul_ { get; set; }
        public string name_ { get; set; }
        public string unit_ { get; set; }
        public decimal price_ { get; set; }
        public string supplier_ { get; set; }
        public string manufacturer_ { get; set; }
        public string category_ { get; set; }
        public int discount_ { get; set; }
        public int count_ { get; set; }
        public string description_ { get; set; }
        public string pic_ { get; set; }
        public Product(string articul_, string name_, string unit_, decimal price_, string supplier_, string manufacturer_, string category_, int discount_, int count_, string description_, string pic_)
        {
            this.articul_ = articul_;
            this.name_ = name_;
            this.unit_ = unit_;
            this.price_ = price_;
            this.supplier_ = supplier_;
            this.manufacturer_ = manufacturer_;
            this.category_ = category_;
            this.discount_ = discount_;
            this.count_ = count_;
            this.description_ = description_;
            this.pic_ = pic_;
        }
    }
}
