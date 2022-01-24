using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC5
{
    public class StraturiModel
    {
        public int id;
        public string material;
        public double grosime;
        public double lambda;

        public StraturiModel(int id, string material, double grosime, double lambda)
        {
            this.id = id;
            this.material = material;
            this.grosime = grosime;
            this.lambda = lambda;
        }


        override
        public string ToString()
        {
            return this.material;
        }

    }
}
