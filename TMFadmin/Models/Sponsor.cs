namespace TMFadmin.Models
{
    public class Sponsor
    {
        private int id {get;}
        //first name
        public string firstname {get; set;}
        //last name
        public string lastname {get; set;}
        //type of sponsor - donor or advertiser
        public string type {get; set;}
        //mailing address
        public Address mailing;
        //billing address
        public Address billing;
        //phone number
        public string phone {get; set;}
        //fax number
        public string fax {get; set;}
        //email address
        public string email {get; set;}
        //whether they are active revenue sources or wish to not be solicited
        protected string activity {get; set;} = "active";
        //additional notes
        protected string notes {get; set;}

        public Sponsor() {
            id = 0;
            firstname  = "";
            lastname = "";
            type = "";
            mailing = new Address();
            billing = new Address();
            phone = "";
            fax = "";
            email = "";
        }
    }
}