namespace CodingChallenge.Models  
{  
    public class DrinkSize  
    {  
        public double Small
        {  
            get;  
            set;  
        }  
        public double Medium
        {  
            get;  
            set;  
        }  
        public double Large
        {  
            get;  
            set;  
        }  
        public double Huge
        {  
            get;  
            set;  
        }  
        public double Mega
        {  
            get;  
            set;  
        }  
        public double Ultra
        {  
            get;  
            set;  
        }  
        public double getPriceBySize(string size)
        {
            double value = 0;
            if(size == "small")
            {
                value = Small;
            } else if (size == "medium")
            {
                value = Medium;
            } else if (size == "large")
            {
                value = Large;
            } else if (size == "huge")
            {
                value = Huge;
            } else if (size == "mega")
            {
                value = Mega;
            } else if (size == "ultra")
            {
                value = Ultra;
            }
            
            return value;
        }
    }  
}