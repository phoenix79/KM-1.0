using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kerbal_Memorial_1._0
{
    class CrewMember
    {
        String KerbalName;
        int KerbalState;
        bool BadS;

        //public CrewMember(String KerbalName, int KerbalState, bool BadS)
        public CrewMember(int KerbalState)
        {
            //this.KerbalName = KerbalName;
            this.KerbalState = KerbalState;
            //this.BadS = BadS;
        }
    }


}
