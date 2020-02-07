namespace TMFadmin.Models
{
    //interface for all sources of revenue
    public abstract class Source {
        protected string _firstname {get; set;}
        protected string _lastname {get; set;}
        protected Address _mailing;
        protected Address _billing;
        protected string _phone {get; set;}
        protected string _fax {get; set;}
        protected string _email {get; set;}
        //protected Datetime _date {get; set;}
        protected string _activity {get; set;} = "active";
        protected string _notes {get; set;}

        public Source() {
            _firstname  = "";
            _lastname = "";
            _mailing = new Address();
            _billing = new Address();
            _phone = "";
            _fax = "";
            _email = "";
           // _date = DateTime.Now.ToString("h:mm:ss tt");
        }
    } 
}