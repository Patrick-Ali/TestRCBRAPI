using System;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;


namespace HttpClientSample
{
    class Program
    {
        static HttpClient client = new HttpClient();
        private static readonly string passPhrase = "l%HJb5N^O@fl0K02H9PsxlR9algJTzK7ARBjJsd3fPG0&GwkrU";

        static void ShowProduct(User user)
        {
            //Console.WriteLine($"Name: {product.Name}\tPrice: " +
                //$"{product.Price}\tCategory: {product.Category}");
        }

        //--------------Create Objects--------------

        static User GenerateUser()
        {
            List<string> names = new List<string>()
            {
                "Andrew",
                "Bob",
                "Charels",
                "Dug",
                "Even",
                "Fred",
                "George",
                "Harry",
                "Ian",
                "Jo",
                "Kevin",
                "Luke",
                "Matt"
            };
            List<string> lastNames = new List<string>()
            {
                "Nolan",
                "Oliver",
                "Peter",
                "Quin",
                "Roger",
                "Steven",
                "Trevor",
                "Ulysses",
                "Victor",
                "William",
                "Xerxes",
                "Yvon",
                "Zach"
            };
            List<string> posistion = new List<string>()
            {
                "Captain",
                "Pit"
            };

            Random random = new Random();
            int rand1 = random.Next(0, 12);
            int rand2 = random.Next(0, 12);
            int rand3 = random.Next(10, 31);
            int rand4 = random.Next(10, 12);
            int rand5 = random.Next(1940, 2001);
            int rand6 = random.Next(0, 2);
            int rand7 = random.Next(0, 12);
            int rand8 = random.Next(1, 100);
            int rand9 = random.Next(1, 20);
            int rand10 = random.Next(1, 20);
            int rand11 = random.Next(1, 1000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(random.Next(1000, 9999));
            builder.Append(RandomString(2, false));
            if (rand3 > 28 && rand4 == 2)
            {
                rand3 = 28;
            }
            if (rand3 > 30 && rand4 == 4 || rand4 == 6 || rand4 == 9 || rand4 == 11)
            {
                rand3 = 30;
            }
            User usering = new User
            {
                FirstName = names[rand1],
                LastName = lastNames[rand2],
                DOB = rand3.ToString() + "/" + rand4.ToString() + "/" + rand5.ToString(),
                Posistion = "Captain",
                Address = rand8.ToString() + " " + lastNames[rand7] + " street",
                PostCode = "CV" + rand9.ToString() + " " + rand10.ToString() + "KS",
                Email = names[rand1] + names[rand2] + rand5.ToString() + "@random" + rand11.ToString() + ".com",
                PhoneNumber = "123456789",
                MobilePhoneNumber = "98745612332",
                Password = "Password",//builder.ToString(),
                City = "Coventry",
                Points = random.Next(0, 200).ToString(),
                Team = "null"
            };
            return usering;
        }

        public static Boat GetBoat(string captain)
        {

            Boat boat = new Boat()
            {
                Beam = "17",

                BeamM = "in",

                Type = "Catamaran",

                DriveSystem = "Flex shaft",

                HullHeight = "9",

                HullHeightM = "in",

                HullMaterial = "Fiberglass",

                Length = "48",

                LengthM = "in",

                MotorSize = "6-pole 1000Kv 56×87mm",

                PropellerSize = "1.4×1.90 and 1.4×2.0",

                Radio = "Spektrum DX2E",

                Scale = "48",

                ScaleM = "in",

                Speed = "55",

                SpeedM = "mph",

                SpeedControl = "Dynamite 160A HV 2S-8S",

                Steering = "In-line rudder with break away",

                Coluors = "Orange, Gray, White",

                Weight = "12",

                WeightM = "lb",

                CaptainID = captain
            };

            return boat;
        }

        public static Team GetTeam(string captain, string pit, string recruiting)
        {
            Team team = new Team()
            {
                CaptainID = captain,
                PitID = pit,
                Recruiting = recruiting
            };
            return team;
        }

        public static EventReg GetEventReg(string team, string eventIn)
        {
            EventReg eventReg = new EventReg()
            {
                EventID = eventIn,
                TeamID = team
            };
            return eventReg;
        }

        public static EventIn GetEvent(byte[] fileBytes)
        {
            Random random = new Random();
            int rand3 = random.Next(1, 31);
            int rand4 = random.Next(1, 12);
            int rand5 = random.Next(2019, 2020);
            if (rand3 > 28 && rand4 == 2)
            {
                rand3 = 28;
            }
            if (rand3 > 30 && rand4 == 4 || rand4 == 6 || rand4 == 9 || rand4 == 11)
            {
                rand3 = 30;
            }
            string tempHold = rand4.ToString();
            if (rand4 < 10) {
                tempHold = "0" + rand4.ToString();
            }
            string tempHoldDay = rand3.ToString();
            if (rand3 < 10)
            {
                tempHoldDay = "0" + rand3.ToString();
            }
            EventIn eventIn = new EventIn()
            {
                VideoURL = "null",
                Name = "Trials"+tempHoldDay,
                Location = "Lake District",
                //Date = tempHoldDay + "/" +  + "/" + ,
                Date = rand5.ToString() + "-" + tempHold + "-" + tempHoldDay,
                TimeStart = "09:00",
                TimeEnd = "18:00",
                Description = "A fun day out to try your teams skill against other like" +
                "minded people.",
                EventFile = fileBytes
            };

            return eventIn;
        }

        //--------------End Create Objects--------------

        //--------------User Access Methods--------------

        static async Task<Uri> CreateUserAsync(User user)
        {
            User crypto = new User();
            crypto.Address = Crypto.Encrypt(user.Address, passPhrase);
            crypto.City = Crypto.Encrypt(user.City, passPhrase);
            crypto.DOB = Crypto.Encrypt(user.DOB, passPhrase);
            crypto.Email = Crypto.Encrypt(user.Email, passPhrase);
            crypto.FirstName = Crypto.Encrypt(user.FirstName, passPhrase);
            crypto.LastName = Crypto.Encrypt(user.LastName, passPhrase);
            crypto.PostCode = Crypto.Encrypt(user.PostCode, passPhrase);
            crypto.Password = Crypto.Encrypt(user.Password, passPhrase);
            crypto.Team = Crypto.Encrypt(user.Team, passPhrase);
            crypto.Posistion = Crypto.Encrypt(user.Posistion, passPhrase);
            crypto.Points = Crypto.Encrypt(user.Points, passPhrase);
            crypto.PhoneNumber = Crypto.Encrypt(user.PhoneNumber, passPhrase);
            crypto.MobilePhoneNumber = Crypto.Encrypt(user.MobilePhoneNumber, passPhrase);

            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:44389/api/1.0/user", crypto);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
           
            return response.Headers.Location;
        }

        static async Task<List<User>> GetUsersAsync(string path)
        {
            List<User> users = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                users = await response.Content.ReadAsAsync<List<User>>();
            }
            return users;
        }

        static async Task<User> GetUserAsync(string path)
        {
            User user = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<User>();
            }
            return user;
        }

        static async Task<User> UpdateUserAsync(User user)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"https://localhost:44389/api/1.0/user/{ user.Id}", user);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            user = await response.Content.ReadAsAsync<User>();
            return user;
        }

        static async Task<HttpStatusCode> DeleteUserAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"https://localhost:44389/api/1.0/user/{id}");
            return response.StatusCode;
        }

        //--------------End User Access Methods--------------

        //--------------Admin Access Methods--------------

        static async Task<Uri> CreateAdminAsync(Admin admin)
        {
            Admin crypto = new Admin();

            crypto.Email = Crypto.Encrypt(admin.Email, passPhrase);

            crypto.Password = Crypto.Encrypt(admin.Password, passPhrase);

            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:44389/api/1.0/admin", crypto);

            response.EnsureSuccessStatusCode();

            // return URI of the created resource.

            return response.Headers.Location;
        }

        static async Task<List<Admin>> GetAdminsAsync(string path)
        {
            List<Admin> admins = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                admins = await response.Content.ReadAsAsync<List<Admin>>();
            }
            return admins;
        }

        static async Task<Admin> GetAdminAsync(string path)
        {
            Admin admin = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                admin = await response.Content.ReadAsAsync<Admin>();
            }
            return admin;
        }

        static async Task<Admin> UpdateAdminAsync(Admin admin)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"https://localhost:44389/api/1.0/admin/{ admin.Id}", admin);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            admin = await response.Content.ReadAsAsync<Admin>();
            return admin;
        }

        static async Task<HttpStatusCode> DeleteAdminAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"https://localhost:44389/api/1.0/admin/{id}");
            return response.StatusCode;
        }

        //--------------End Admin Access Methods--------------

        //--------------Login Access Methods--------------

        static async Task<OutLogin> Login(Login login)
        {
            string sendEmail = Crypto.Encrypt(login.Email, passPhrase);
            string sendPassword = Crypto.Encrypt(login.Password, passPhrase);
            Login logSend = new Login()
            {
                Email = sendEmail,
                Password = sendPassword
            };

            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:44389/api/1.0/login", logSend);
            response.EnsureSuccessStatusCode();
            var tempURL = response.Headers.Location;
            Console.WriteLine(tempURL);
            User tempUser = await GetUserAsync(tempURL.ToString());
            string id = tempUser.Id;
            string email = Crypto.Decrypt(tempUser.Email, passPhrase);
            OutLogin final = new OutLogin()
            {
                Email = email,
                Id = id
            };
            return final;
            //OutLogin temp = response.Content.ReadAsAsync<OutLogin>();

        }

        //--------------End Login Access Methods--------------

        //--------------Admin Login Access Methods--------------

        static async Task<OutLogin> AdminLogin(Login login)
        {
            string sendEmail = Crypto.Encrypt(login.Email, passPhrase);
            string sendPassword = Crypto.Encrypt(login.Password, passPhrase);
            Login logSend = new Login()
            {
                Email = sendEmail,
                Password = sendPassword
            };

            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:44389/api/1.0/adminlogin", logSend);
            Console.Write(response.IsSuccessStatusCode);
            response.EnsureSuccessStatusCode();
            var tempURL = response.Headers.Location;
            
            Console.WriteLine(tempURL);
            Admin tempAdmin = await GetAdminAsync(tempURL.ToString());
            string id = tempAdmin.Id;
            string email = Crypto.Decrypt(tempAdmin.Email, passPhrase);
            OutLogin final = new OutLogin()
            {
                Email = email,
                Id = id
            };
            return final;
            //OutLogin temp = response.Content.ReadAsAsync<OutLogin>();

        }

        //--------------End Admin Login Access Methods--------------

        //--------------Event Access Methods--------------

        static async Task<Uri> CreateEventAsync(EventIn eventIn) {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:44389/api/1.0/event", eventIn);
            response.EnsureSuccessStatusCode();
            var tempURL = response.Headers.Location;
            Console.WriteLine(tempURL);
            return response.Headers.Location;
        }

        static async Task<EventIn> GetEventAsync(string path)
        {
            EventIn eventIn = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                eventIn = await response.Content.ReadAsAsync<EventIn>();
            }
            return eventIn;
        }



        static async Task<List<Event>> GetEventsAsync(string path)
        {
            List<Event> events = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                events = await response.Content.ReadAsAsync<List<Event>>();
            }
            return events;
        }

        static async Task<EventIn> UpdateEventAsync(EventIn eventIn)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"https://localhost:44389/api/1.0/event/{ eventIn.Id}", eventIn);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            eventIn = await response.Content.ReadAsAsync<EventIn>();
            return eventIn;
        }

        static async Task<HttpStatusCode> DeleteEventAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"https://localhost:44389/api/1.0/event/{id}");
            return response.StatusCode;
        }

        //--------------End Event Access Methods--------------

        //--------------Team Access Methods--------------

        static async Task<Uri> CreateTeamAsync(Team team)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:44389/api/1.0/team", team);
            response.EnsureSuccessStatusCode();
            var tempURL = response.Headers.Location;
            Console.WriteLine(tempURL);
            return response.Headers.Location;
        }

        static async Task<Team> GetTeamAsync(string path)
        {
            Team team = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                team = await response.Content.ReadAsAsync<Team>();
            }
            return team;
        }

        static async Task<List<Team>> GetTeamsAsync(string path)
        {
            List<Team> teams = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                teams = await response.Content.ReadAsAsync<List<Team>>();
            }
            return teams;
        }

        static async Task<Team> UpdateTeamAsync(Team team)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"https://localhost:44389/api/1.0/team/{ team.Id}", team);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            team = await response.Content.ReadAsAsync<Team>();
            return team;
        }

        static async Task<HttpStatusCode> DeleteTeamAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"https://localhost:44389/api/1.0/team/{id}");
            return response.StatusCode;
        }

        //--------------End Team Access Methods--------------

        //--------------Boat Access Methods--------------

        static async Task<Uri> CreateBoatAsync(Boat boat)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:44389/api/1.0/boat", boat);
            response.EnsureSuccessStatusCode();
            var tempURL = response.Headers.Location;
            Console.WriteLine(tempURL);
            return response.Headers.Location;
        }

        static async Task<Boat> GetBoatAsync(string path)
        {
            Boat boat = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                boat = await response.Content.ReadAsAsync<Boat>();
            }
            return boat;
        }

        static async Task<List<Boat>> GetBoatsAsync(string path)
        {
            List<Boat> boat = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                boat = await response.Content.ReadAsAsync<List<Boat>>();
            }
            return boat;
        }

        static async Task<Boat> UpdateBoatAsync(Boat boat)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"https://localhost:44389/api/1.0/boat/{ boat.Id}", boat);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            boat = await response.Content.ReadAsAsync<Boat>();
            return boat;
        }

        static async Task<HttpStatusCode> DeleteBoatAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"https://localhost:44389/api/1.0/boat/{id}");
            return response.StatusCode;
        }

        //--------------End Boat Access Methods--------------

        //--------------EventReg Access Methods--------------

        static async Task<Uri> CreateEventRegAsync(EventReg eventReg)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:44389/api/1.0/eventReg", eventReg);
            response.EnsureSuccessStatusCode();
            var tempURL = response.Headers.Location;
            Console.WriteLine(tempURL);
            return response.Headers.Location;
        }

        static async Task<EventReg> GetEventRegAsync(string path)
        {
            EventReg eventReg = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                eventReg = await response.Content.ReadAsAsync<EventReg>();
            }
            return eventReg;
        }

        static async Task<List<EventReg>> GetEventRegsAsync(string path)
        {
            List<EventReg> eventReg = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                eventReg = await response.Content.ReadAsAsync<List<EventReg>>();
            }
            return eventReg;
        }

        static async Task<EventReg> UpdateEventRegAsync(EventReg eventReg)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"https://localhost:44389/api/1.0/eventReg/{ eventReg.Id}", eventReg);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            eventReg = await response.Content.ReadAsAsync<EventReg>();
            return eventReg;
        }

        static async Task<HttpStatusCode> DeleteEventRegAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"https://localhost:44389/api/1.0/eventReg/{id}");
            return response.StatusCode;
        }

        //--------------End EventReg Access Methods--------------

        //--------------Helper Methods--------------

        // Taken from https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/

        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        public static async Task<bool> SimulateDownloadingFile(Uri uri) {
            //Simualte downloading the file, can change file create to 
            //wherever and whatever pdf to be created
            EventIn tempEvent = await GetEventAsync(uri.ToString());
            Console.WriteLine(tempEvent.Location);
            using (var filestream = File.Create(@"C:\Users\patri\Downloads\Test20.pdf"))
            {
                filestream.Write(tempEvent.EventFile, 0, tempEvent.EventFile.Length);
                filestream.Close();
                return true;
            }
        }

        static User DecryptUser(User user)
        {
            user.Address = Crypto.Decrypt(user.Address, passPhrase);
            user.City = Crypto.Decrypt(user.City, passPhrase);
            user.DOB = Crypto.Decrypt(user.DOB, passPhrase);
            user.Email = Crypto.Decrypt(user.Email, passPhrase);
            user.FirstName = Crypto.Decrypt(user.FirstName, passPhrase);
            user.LastName = Crypto.Decrypt(user.LastName, passPhrase);
            user.PostCode = Crypto.Decrypt(user.PostCode, passPhrase);
            user.Password = Crypto.Decrypt(user.Password, passPhrase);
            user.Team = Crypto.Decrypt(user.Team, passPhrase);
            user.Posistion = Crypto.Decrypt(user.Posistion, passPhrase);
            user.PhoneNumber = Crypto.Decrypt(user.PhoneNumber, passPhrase);
            user.MobilePhoneNumber = Crypto.Decrypt(user.MobilePhoneNumber, passPhrase);
            user.Points = Crypto.Decrypt(user.Points, passPhrase);
            return user;
        }

        //--------------End Helper Methods--------------


        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                //Simulating creating the user
                //User user = GenerateUser();

                /*Admin admin = new Admin()
                {
                    Email = "admin2@random.com",
                    Password = "password2"
                };*/

                /*
                var uriTemp = await CreateAdminAsync(admin);
                Admin adminTemp = await GetAdminAsync(uriTemp.ToString());
                Console.WriteLine(adminTemp.Email + " " + adminTemp.Password + " " + adminTemp.Id);
                */

               /* Login tempLogin = new Login();
                tempLogin.Email = admin.Email;
                tempLogin.Password = admin.Password;
                
                OutLogin tempAdmin = await AdminLogin(tempLogin);
                Console.WriteLine(tempAdmin.Email + " " + tempAdmin.Id);*/


                List<User> captains = new List<User>();
                List<User> pit = new List<User>();
                List<Boat> boats = new List<Boat>();
                List<Team> teams = new List<Team>();
                List<EventIn> events = new List<EventIn>();
                List<EventReg> eventRegs = new List<EventReg>();

                /*for (int i = 0; i <= 100; i++) {
                    User user = GenerateUser();
                    Console.WriteLine(i);
                    //Console.WriteLine(user.FirstName + " " + user.LastName
                    // + " " + user.DOB + " " + user.Email + " " + user.Address + " " + user.Password
                    // + " " + user.Posistion);
                    User crypto = new User();
                    if (user.Posistion == "Captain")
                    {
                        var uriTemp = await CreateUserAsync(user);
                        Console.WriteLine("User Captain: " + uriTemp);
                        User userTemp = await GetUserAsync(uriTemp.ToString());
                        User decUser = DecryptUser(userTemp);
                        Boat tempBoat = GetBoat(userTemp.Id);
                        var uriTempBoat = await CreateBoatAsync(tempBoat);
                        Console.WriteLine("Boat: " + uriTempBoat);
                        Boat addBoat = await GetBoatAsync(uriTempBoat.ToString());
                        Team team = GetTeam(decUser.Id, "null", "true");
                        var uriTemp2 = await CreateTeamAsync(team);
                        Team tempTeam = await GetTeamAsync(uriTemp2.ToString());
                        decUser.Team = tempTeam.Id;
                        crypto.FirstName = Crypto.Encrypt(decUser.FirstName, passPhrase);
                        crypto.Posistion = Crypto.Encrypt(decUser.Posistion, passPhrase);
                        crypto.Address = Crypto.Encrypt(decUser.Address, passPhrase);
                        crypto.City = Crypto.Encrypt(decUser.City, passPhrase);
                        crypto.DOB = Crypto.Encrypt(decUser.DOB, passPhrase);
                        crypto.Email = Crypto.Encrypt(decUser.Email, passPhrase);
                        crypto.LastName = Crypto.Encrypt(decUser.LastName, passPhrase);
                        crypto.PostCode = Crypto.Encrypt(decUser.PostCode, passPhrase);
                        crypto.Password = Crypto.Encrypt(decUser.Password, passPhrase);
                        crypto.Team = Crypto.Encrypt(decUser.Team, passPhrase);
                        crypto.Points = Crypto.Encrypt(decUser.Points, passPhrase);
                        crypto.PhoneNumber = Crypto.Encrypt(decUser.PhoneNumber, passPhrase);
                        crypto.MobilePhoneNumber = Crypto.Encrypt(decUser.MobilePhoneNumber, passPhrase);
                        crypto.Id = decUser.Id;
                        await UpdateUserAsync(crypto);
                        captains.Add(userTemp);
                    }
                    if (user.Posistion == "Pit")
                    {
                        Console.WriteLine("Hello");
                        var uriTemp = await CreateUserAsync(user);
                        Console.WriteLine("User Pit: " + uriTemp);
                        User userTemp = await GetUserAsync(uriTemp.ToString());
                        pit.Add(userTemp);
                    }
                }

                  int count = 0;
                while (count < captains.Count) {
                    Team team = GetTeam(captains[count].Id, "null", "true");
                    var uriTemp = await CreateTeamAsync(team);
                    Team tempTeam = await GetTeamAsync(uriTemp.ToString());
                    teams.Add(tempTeam);
                    count++;
                }*/
                
              for (int i = 0; i <= 100; i++)
                {
                    //Simulating Upload of file, can change file opean read to any pdf
                    FileStream stream = File.OpenRead(@"C:\Users\patri\Downloads\TestEventDocument.pdf");
                    byte[] fileBytes = new byte[stream.Length];
                    stream.Read(fileBytes, 0, fileBytes.Length);
                    EventIn temp = GetEvent(fileBytes);
                    var uri = await CreateEventAsync(temp);
                    //Console.WriteLine(uri);
                    stream.Close();
                    EventIn tempEvent = await GetEventAsync(uri.ToString());
                    events.Add(tempEvent);
                }
                
                /*count = 0;
                while (count < teams.Count && count < events.Count)
                {
                    EventReg eventReg = GetEventReg(teams[count].Id, events[count].Id);
                    var uriEventReg = await CreateEventRegAsync(eventReg);
                    EventReg tempReg = await GetEventRegAsync(uriEventReg.ToString());
                    eventRegs.Add(tempReg);
                    count++;
                }
                

                List<User> temp1 = await GetUsersAsync("https://localhost:44389/api/1.0/user");
                List<Boat> temp2 = await GetBoatsAsync("https://localhost:44389/api/1.0/boat");
                List<Team> temp3 = await GetTeamsAsync("https://localhost:44389/api/1.0/team");
                List<Event> temp4 = await GetEventsAsync("https://localhost:44389/api/1.0/event");
                List<EventReg> temp5 = await GetEventRegsAsync("https://localhost:44389/api/1.0/eventReg");
                */
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}