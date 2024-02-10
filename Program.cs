using Turboazmini.Enums;
using Turboazmini.Models;

namespace Turboazmini
{
    internal class Program
    {
        static List<Marka> markaList = new();
        static List<Models.Models> modelList = new();
        static List<Announcement> anouncementList = new();
        static void Main(string[] args)
        {
            int answer;
            do
            {
                Console.WriteLine("1 - Marka elave ele: ");
                Console.WriteLine("2 - Marka sil :");
                Console.WriteLine("3 - Marka hamisin goster: ");
                Console.WriteLine("4 - Marka Id ile axtar: ");
                Console.WriteLine("5 - Marka duzelish ele: ");


                Console.WriteLine("6 - Model elave ele: ");
                Console.WriteLine("7 - Model sil: ");
                Console.WriteLine("8 - Butun modelleri goster: ");
                Console.WriteLine("9 - Model Id ile axtar: ");
                Console.WriteLine("10 - Modele duzelish ele: ");


                Console.WriteLine("11 - Elan elave ele: ");

                answer = Exstensions.Helper.ReadInt(" Siyhidan secim edin", "Sehv daxil etdiniz");


                switch (answer)
                {
                    case 1:
                        AddNewMarka();
                        break;
                    case 2:
                        DeleteMarka();
                        break;
                    case 3:
                        GetAllMarka();
                        break;
                    case 4:
                        GetMarkaById();
                        break;
                    case 5:
                        EditMarka();
                        break;
                    case 6:
                        AddNewModel();
                        break;
                    case 7:
                        DeleteModel();
                        break;
                    case 8:
                        GetAllModedls();
                        break;
                    case 9:
                        GetModelById();
                        break;
                    case 10:
                        EditModel();
                        break;
                    case 11:
                        AddAnouncement();
                        break;
                    default:
                        break;
                }

            } while (true);


        }

        private static void AddAnouncement()
        {
            int modelId;
            double price;
            int march;
            int fuelTypeNum;
            int gearBoxNum;
            int transmissionNum;
            int bannerNum;

            Console.WriteLine("Elan yaratmaq ucun Modellerden birini secin");

            foreach (var item in modelList)
            {
                Console.WriteLine($"Id - {item.Id} Adi - {item.Name}  Marka - {item.Marka.Name}");
            }
        l1:
            modelId = Exstensions.Helper.ReadInt("Modelin Id-sini daxil edin", "Sehv daxil etdiniz");
            Models.Models model = modelList.FirstOrDefault(m => m.Id == modelId);
            if (model == null)
            {
                Console.WriteLine("Secdiyiniz Id-ile model yoxdur !");
                goto l1;
            }

        l2:
            price = Exstensions.Helper.ReadDouble("Qiymeti daxil edin", "Sehv daxil etdiniz!");
            if (price < 300)
            {
                Console.WriteLine("Daxil etdiyiniz giymet minimumdan balacadi!");
                goto l2;
            }
        l3:
            march = Exstensions.Helper.ReadInt("Avtomobilin yurushunu daxil edin!", "Sehv daxil etdiniz!");
            if (march < 0)
            {
                Console.WriteLine("Yurush 0-dan balaca ola bilmez!");
                goto l3;
            }


            foreach (var item in Enum.GetValues(typeof(TypeOfFuel)))
            {
                Console.WriteLine($"{(int)item}-{item}");
            }
            TypeOfFuel fuelType;
        l4:
            fuelTypeNum = Exstensions.Helper.ReadInt("FuelType Secin:", "Sehv daxil etdiniz!");

            if (Enum.IsDefined(typeof(TypeOfFuel), fuelTypeNum))
            {
                fuelType = (TypeOfFuel)fuelTypeNum;
            }
            else
            {
                Console.WriteLine("Sehv secim etdiniz1 yeniden cehd edin!");
                goto l4;
            }

            TypeOfGearBox gearBox;
        l5:
            foreach (var item in Enum.GetValues(typeof(TypeOfGearBox)))
            {
                Console.WriteLine($"{(int)item}-{item}");
            }
            gearBoxNum = Exstensions.Helper.ReadInt("Suretler qutusunu Secin:", "Sehv daxil etdiniz!");

            if (Enum.IsDefined(typeof(TypeOfGearBox), gearBoxNum))
            {
                gearBox = (TypeOfGearBox)gearBoxNum;
            }
            else
            {
                Console.WriteLine("Sehv secim etdiniz1 yeniden cehd edin!");
                goto l5;
            }

            TypeOfTransmission transmission;
            foreach (var item in Enum.GetValues(typeof(TypeOfTransmission)))
            {
                Console.WriteLine($"{(int)item}-{item}");
            }
        l6:
            transmissionNum = Exstensions.Helper.ReadInt("Oturucunu Secin:", "Sehv daxil etdiniz!");

            if (Enum.IsDefined(typeof(TypeOfTransmission), transmissionNum))
            {
                transmission = (TypeOfTransmission)transmissionNum;
            }
            else
            {
                Console.WriteLine("Sehv secim etdiniz1 yeniden cehd edin!");
                goto l6;
            }
        l7:
            TypeOfBan banner;
            foreach (var item in Enum.GetValues(typeof(TypeOfBan)))
            {
                Console.WriteLine($"{(int)item}-{item}");
            }

            bannerNum = Exstensions.Helper.ReadInt("Ban novunu Secin:", "Sehv daxil etdiniz!");

            if (Enum.IsDefined(typeof(TypeOfBan), bannerNum))
            {
                banner = (TypeOfBan)bannerNum;
            }
            else
            {
                Console.WriteLine("Sehv secim etdiniz1 yeniden cehd edin!");
                goto l7;
            }

            Announcement anouncement = new Announcement();
            anouncement.TypeOfBan = banner;
            anouncement.TypeOfTransmission = transmission;
            anouncement.Price = price;
            anouncement.TypeOfGearBox = gearBox;
            anouncement.TypeOfFuel = fuelType;
            anouncement.March = march;
            anouncement.Models = model;

            anouncementList.Add(anouncement);

            Console.Clear();
            Console.WriteLine("Yeni elan elave edildi !");
            Console.WriteLine($"Info : Id-{anouncement.Id}, Banner-{anouncement.TypeOfBan} Yurush - {anouncement.March} " +
                $" Suretler qutusu novu - {anouncement.TypeOfGearBox} Fuel Type - {anouncement.TypeOfFuel} Modeli - {anouncement.Models}" +
                $"Marka - {anouncement.Models.Marka.Name}  Qiymeti - {anouncement.Price} Oturucu novu - {anouncement.TypeOfTransmission}");

        }

        private static void EditModel()
        {
            int modelId;

            foreach (var item in modelList)
            {
                Console.WriteLine($"Id - {item.Id} Adi - {item.Name}  Marka - {item.Marka.Name}");
            }
        l1:
            modelId = Exstensions.Helper.ReadInt("Duzelish etmek istediyiniz modelin Id-sini daxil edin !", "Sehv daxil etdiniz");
            Models.Models model = modelList.FirstOrDefault(m => m.Id == modelId);
            if (model == null)
            {
                Console.WriteLine($"{modelId} - Id li Model siyahida yoxdur!");
                goto l1;
            }

            string newModelName = Exstensions.Helper.ReadString("Modelin yeni adini daxil edin!", "Sehv daxil etdiniz");

            foreach (var item in markaList)
            {
                Console.WriteLine($"Id - {item.Id}, Adi - {item.Name}");
            }

            int markaId;

        l2:
            markaId = Exstensions.Helper.ReadInt("Yeni markanin Id-sini daxil ele", "Sehv daxil etdiniz!");
            Marka marka = markaList.FirstOrDefault(m => m.Id == markaId);
            if (marka == null)
            {
                Console.WriteLine($"{markaId} - Id li Marka siyahida yoxdur!");
                goto l2;
            }

            model.Marka = marka;
            model.Name = newModelName;

            Console.WriteLine("Deyisiklik edildi ! \n");


        }

        private static void GetModelById()
        {
            int modelId;
        l1:
            modelId = Exstensions.Helper.ReadInt("Tapmaq istediyiniz Modelin Id-sini daxil edin", "Sehv daxil etdiniz");

            Models.Models model = modelList.FirstOrDefault(x => x.Id == modelId);
            if (model == null)
            {
                Console.WriteLine("Bu Id-ile model tapilmadi!");
                goto l1;
            }

            Console.WriteLine($"Id - {model.Id} Adi - {model.Name}  Markasi - {model.Marka.Name}");
            Console.WriteLine("\n");

        }

        private static void GetAllModedls()
        {
            if (modelList.Count < 1)
            {
                Console.WriteLine("Model siyahisi boshdur!");
                return;
            }

            foreach (var item in modelList)
            {
                Console.WriteLine($"Id - {item.Id} Adi - {item.Name}  Marka - {item.Marka.Name}");
            }

            Console.WriteLine("\n");

        }

        private static void DeleteModel()
        {
            int deleteId;
            Console.WriteLine();
            foreach (var item in modelList)
            {
                Console.WriteLine($"Id - {item.Id} Adi - {item.Name}  Marka - {item.Marka.Name}");
            }
        l1:
            deleteId = Exstensions.Helper.ReadInt("Silmek istediyiniz modelin Id-sini daxil edin!", "Sehv daxil etdiniz !");
            Models.Models model = modelList.FirstOrDefault(m => m.Id == deleteId);
            if (model is null)
            {
                Console.WriteLine("Daxil etdiyiniz Id- ile model movcud deil!");
                goto l1;
            }

            modelList.Remove(model);
            Console.WriteLine("Silindi!\n");

        }

        private static void AddNewModel()
        {
            if (markaList.Count < 1)
            {
                Console.WriteLine("Marka siyahisi boshdu ! Zehmet olmasa Marka elave edin!");
                return;
            }

            string modelName = Exstensions.Helper.ReadString("Modelin adini daxil edin :", "Sehv daxil etdiniz");
            int markaId;
            foreach (var item in markaList)
            {
                Console.WriteLine($"Id - {item.Id}, Adi - {item.Name}");
            }

        l1:
            markaId = Exstensions.Helper.ReadInt("Modelin Markasini secin !", "Sehv daxil etdiniz !");
            Marka marka = markaList.FirstOrDefault(m => m.Id == markaId);
            if (marka is null)
            {
                Console.WriteLine("Sehv Id- daxil etmisiz!");
                goto l1;
            }

            Models.Models model = new Models.Models();
            model.Marka = marka;
            model.Name = modelName;

            modelList.Add(model);

            Console.WriteLine("Elave olundu ! \n");

        }

        private static void EditMarka()
        {
            int markaId;
            foreach (Marka item in markaList)
            {
                Console.WriteLine($"Id - {item.Id}, Adi - {item.Name}");
            }
        l1:
            markaId = Exstensions.Helper.ReadInt("Deyisiklik etmek istediyiniz Markanin Id-sini daxil edin", "Sehv daxil etdiniz");
            Marka marka = markaList.FirstOrDefault(m => m.Id == markaId);
            if (marka is null)
            {
                Console.WriteLine($"{markaId}-li marka tapilmadi");
                goto l1;

            }

            string newMarkaName = Exstensions.Helper.ReadString("Markanin yeni adini daxil edin:", "Sehv daxil etdiniz");
            marka.Name = newMarkaName;

            Console.WriteLine("Deyisiklik edildi! \n");

        }

        private static void GetMarkaById()
        {
            int markaId = Exstensions.Helper.ReadInt("Markanin Id-sini daxil edin", "Sehv daxil etdiniz");
            Marka marka = markaList.FirstOrDefault(m => m.Id == markaId);
            if (marka is null)
            {
                Console.WriteLine($"{markaId}-li marka tapilmadi");
            }

            Console.WriteLine($"Id - {marka.Id} Adi - {marka.Name} \n");
        }

        private static void DeleteMarka()
        {
            if (markaList.Count < 1)
            {
                Console.WriteLine("Siyahida marka yoxdu !");
                return;
            }

        l1:
            int markaId = Exstensions.Helper.ReadInt("Markanin Id-sini daxil edin", "Sehv daxil etdiniz");
            Marka marka = markaList.FirstOrDefault(m => m.Id == markaId);
            if (marka is null)
            {
                Console.WriteLine($"{markaId}-li marka tapilmadi");
                goto l1;
            }

            markaList.Remove(marka);
            Console.WriteLine("Silindi ! \n");

        }

        private static void GetAllMarka()
        {
            if (markaList.Count > 0)
            {
                foreach (var item in markaList)
                {
                    Console.WriteLine($"Id - {item.Id}, Adi - {item.Name}");
                }
            }
            else
            {
                Console.WriteLine("Marka siyahisi boshdu ! \n");
            }


        }

        private static void AddNewMarka()
        {
            string markaName;
        l1:
            Console.Write("Markanin adini daxil edin: ");
            markaName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(markaName) || markaName.Length < 2)
            {
                Console.WriteLine("Bosh olmaz ve minimum simvol 3 eded !");
                goto l1;
            }

            Marka marka = new Marka()
            {
                Name = markaName,
            };

            markaList.Add(marka);

            Console.WriteLine("Elave olundu! \n");

        }
    }
}
