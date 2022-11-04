using System.Text;
using System.IO;
using System.Xml.Serialization;
namespace Wordle{
    public class User{

        [XmlAttribute]
        public string username {get;set;}
        public string password {get;set;}
        public int wins {get;set;}
        public int losses {get;set;}
        public double averageTurns {get;set;}

        public int[] turns {get;set;} // turns to win by index

        public XmlSerializer Serializer{get;} = new(typeof(List<User>));

        public User(){}
        public User(string username,string password){
            this.username = username;
            this.password = password;
            this.wins =0;
            this.losses=0;
            this.averageTurns=0;
            this.turns = new int[]{0,0,0,0,0,0,0};
        }
        public User(string username, string password,int wins, int losses,double averageTurns, int[] turns){
            this.username = username;
            this.password = password;
            this.wins = wins;
            this.losses = losses;
            this.averageTurns =averageTurns;
            this.turns = turns;

        }
        public void updateRecord(bool win,int turn){
            if(win){
                this.wins++;
                this.turns[turn]++;
                this.averageTurns = findAverage(turn);
                // int sum=0;
                // int count=0;
                // for(int i=0;i<6;i++){
                //     sum += (turns[i]*i);
                //     count += turns[i];
                // }
                // this.averageTurns=sum/count;
            }
            else{
                this.losses++;
            }
        }

        public double findAverage(int turn){
            int sum=0;
            int count=0;
            for(int i=1;i<6;i++){
                sum += (turns[i]*i);
                count += turns[i];
            }
            return this.averageTurns=sum/count;
        }
        public string displayRecord(string path, List<User> records){
            //string[] records = File.ReadAllLines(path);
            StringBuilder result = new StringBuilder();

            result.AppendLine("Player \t\t Wins \t\t Losses \t Average Turns to win");
            foreach(User record in records){
                //string[] current = record.Split(", ");
                result.AppendLine($"{record.username} \t\t {record.wins}\t\t {record.losses} \t\t{record.averageTurns}");
                //result.AppendLine($"{current[0]} \t\t {current[1]}\t\t {current[2]} \t\t{current[3]}");
            
            //result.AppendLine($"Player : \t{this.username}\t\t Wins : {this.wins}\t\t Losses : {this.losses}\t\t Average turns to win : {this.averageTurns}");
            }
            return result.ToString();
            
        }
        public void saveRecord(string path){
            //SerializeAsXml();
            // StringBuilder sb = new StringBuilder();
            // sb.AppendLine($"{this.username}, {this.wins}, {this.losses}, {this.averageTurns}, {this.turns[1]}, {this.turns[2]}, {this.turns[3]}, {this.turns[4]}, {this.turns[5]}");
            // File.AppendAllText(path,sb.ToString());
        }

        public void SerializeAsXml(List<User> records){
            // List<User> users = new List<User>();
            // users.Add(this);

            var newStringWritter = new StringWriter();
            Serializer.Serialize(newStringWritter,records); //take users data and serialize it and put it in new stringWriter, data we want to send
            newStringWritter.Close();

            File.WriteAllText("./xml",newStringWritter.ToString());
        }

        public List<User> readFromXml(){
            StreamReader reader = new StreamReader("./xml");
            var records = (List<User>?)Serializer.Deserialize(reader);
            reader.Close();
            return records;
        }
        
        public void update(User users){
            this.wins += users.wins;
            this.losses += users.losses;
            for(int i=1;i<6;i++){
                this.turns[i] += users.turns[i];
            }


            int sum=0;
            int count=0;
            for(int i=1;i<6;i++){
                sum += (this.turns[i]*i);
                count += this.turns[i];
            }
            this.averageTurns=sum/count;
            //this.updateRecord(users);// += users.averageTurns;

            //return users;
        }
    }
}