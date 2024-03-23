using Microsoft.VisualBasic.FileIO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Xml;
using Turboazmini.Entity;
using Turboazmini.Enums;
using Turboazmini.Extensions;
using Turboazmini.Models.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Turboazmini.Main
{
    internal class Program
    {
        

        static  AppDbContext db = new AppDbContext();
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            var ci = new CultureInfo("az");
            Thread.CurrentThread.CurrentCulture = ci;

//-----------------------------------------------------------------------------------------------------------------

            Helper.Print("TURBO.AZ -a XOŞ GƏLMİSİNİZ!!!");

        l1:
            Enum menuOption = Helper.ChooseOption<MenuOptions>("Zəhmət olmasa kateqoriya seçin:");
            switch (menuOption)
            {
//Avtomobil
                case MenuOptions.AddAd:
                    Console.Clear();
                    AddAnnouncement();
                    Console.ReadKey();
                    goto l1;

                case MenuOptions.EditAd:
                    Console.Clear();
                    EditAnnouncement();
                    Console.ReadKey();
                    goto l1;

                case MenuOptions.DeleteAd:
                    Console.Clear();
                    DeleteAnnouncement();
                    Console.ReadKey();
                    goto l1;

                case MenuOptions.SearchAdById:
                    Console.Clear();
                    GetAnnouncementById();
                    Console.ReadKey();
                    goto l1;

                case MenuOptions.ShowAllAds:
                    Console.Clear();
                    GetAllAnnouncement();
                    Console.ReadKey();
                    goto l1;

//MODEL

                case MenuOptions.AddModel: 
                    Console.Clear();
                    AddNewModel();
                    goto l1;

                case MenuOptions.EditModel:
                    Console.Clear();
                    EditModel();
                    goto l1;

                case MenuOptions.DeleteModel:
                    Console.Clear();
                    DeleteModel();
                    goto l1;

                case MenuOptions.SearchModelById:
                    Console.Clear();
                    GetModelById();
                    Console.ReadKey();
                    goto l1;

                case MenuOptions.ShowAllModels:
                    Console.Clear();
                    GetAllModels();
                    Console.ReadKey();
                    goto l1;
//BRAND
                case MenuOptions.AddBrand:
                    Console.Clear();
                    AddNewMarka();
                   db.SaveChanges();
                    goto l1;

                case MenuOptions.EditBrand:
                    Console.Clear();
                    EditMarka();
                    goto l1;

                case MenuOptions.DeleteBrand:
                    Console.Clear();
                    DeleteMarka();
                    goto l1;

                case MenuOptions.SearchBrandById: 
                    Console.Clear();
                    GetMarkaById();
                    Console.ReadKey();
                    goto l1;

                case MenuOptions.ShowAllBrands:
                    Console.Clear();
                    GetAllMarka();
                    Console.ReadKey();
                    goto l1;

                case MenuOptions.Exit:
                    Console.WriteLine();
                    Helper.Print("Proqramımıza etibar və istifadə etdiyiniz üçün sizə minnətdarıq");
                    Environment.Exit(0);
                    break;
            }

        }
//NEW METHOD
        public static void GetAllAnnouncement()
        {
            var query = from m in db.Models
                        join b in db.Brands on m.BrandId equals b.Id
                        join c in db.CarAnnouncements on m.Id equals c.ModelId
                        select new
                        {
                            c.Id,
                            c.March,
                            c.Banner,
                            c.GearBox,
                            c.FuelType,
                            ModelName = m.Name,
                            BrandName = b.Name,
                            c.Price,
                            c.Transmission
                        };
            if (query.Any())
            {
                foreach (var item in query)
                {
                    Console.WriteLine($"Info : Id-{item.Id}\nBan növü-{item.Banner}\nYürüş-{item.March}\n" +
                        $"Sürətlər qutusu-{item.GearBox}\nYanacaq növü-{item.FuelType}\nModeli-{item.ModelName}\n" +
                        $"Marka{item.BrandName}\nQiyməti-{item.Price}\nÖtürücü növü-{item.Transmission}\n");

                }
            }

            else
            {
                Console.WriteLine("Elan siyahısı boşdur ! Zəhmət olmasa elan əlavə edin \n");
            }

            db.SaveChanges();

        }
//NEW METHOD
        public static void GetAnnouncementById()
        {
            int announcementId;

            var query = from m in db.Models
                        join b in db.Brands on m.BrandId equals b.Id
                        join c in db.CarAnnouncements on m.Id equals c.ModelId
                        select new
                        {
                            c.Id,
                            c.March,
                            c.Banner,
                            c.GearBox,
                            c.FuelType,
                            ModelName = m.Name,
                            BrandName = b.Name,
                            c.Price,
                            c.Transmission
                        };
            foreach (var item in query)
            {
                Console.WriteLine($"Id nömrəsi-{item.Id}");
            }
        l1:
            announcementId = Helper.ReadInt("Tapmaq istədiyiniz Elanın Id-sini daxil edin", "Xəta!!! Id səhv daxil edilib!");

            var announcement = query.FirstOrDefault(x => x.Id == announcementId);

            if (announcement == null)
            {
                Console.WriteLine("Daxil edilən Id-ə uyğun elan tapılmadı!");
                goto l1;
            }

            Console.WriteLine($" Information Id-{announcement.Id}\nBan növü - {announcement.Banner}\nYürüş - {announcement.March}\n" +
                $" Sürətlər qutusunun növü - {announcement.GearBox}\nYanacaq növü - {announcement.FuelType}\nModel - {announcement.ModelName}\n " +
                $" Marka - {announcement.BrandName}\nQiyməti - {announcement.Price}\n Ötürücü növü{announcement.Transmission}\n");

            db.SaveChanges();
            Console.WriteLine("\n");
        }
//NEW METHOD
        private static void EditAnnouncement()
        {
            var query = from m in db.Models
                        join b in db.Brands on m.BrandId equals b.Id
                        join c in db.CarAnnouncements on m.Id equals c.ModelId
                        select new
                        {
                            c.Id,
                            c.March,
                            c.Banner,
                            c.GearBox,
                            c.FuelType,
                            ModelName = m.Name,
                            BrandName = b.Name,
                            c.Price,
                            c.Transmission
                        };
            foreach (var item in query.ToList())
            {
                Console.WriteLine($"Information: Id-{item.Id}, Ban növü-{item.Banner}, Yürüş - {item.March}" +
                  $" Sürətlər qutusu növü-{item.GearBox}, Yanacaq növü-{item.FuelType}, Modeli - {item.ModelName}" +
                  $" Marka-{item.BrandName}, Qiyməti-{item.Price}, Ötürücü növü-{item.Transmission}");
            }
        l1:
            var announcementId = Helper.ReadInt("Düzəliş etmək istədiyiniz Elanın Id-sini daxil edin !", "Səhv daxil etdiniz!");
            var announcement = db.CarAnnouncements.FirstOrDefault(m => m.Id == announcementId);
            if (announcement == null)


            {
                Console.WriteLine($"{announcementId}-Xəta!!! Id-li Elan siyahıda tapılmadı! Zəhmət olmasa yenidən daxil edin");
                goto l1;
            }
        l2:
            var price = Helper.ReadDouble("Elan üçün qiyməti daxil edin", "Səhv Daxil etdiniz");
            if (price < 100)
            {
                Console.WriteLine("Daxil etdiyiniz qiymət minimumdan azdır");
                goto l2;
            }
            int modelId;

            foreach (var item in db.Models.ToList())
            {
                Console.WriteLine($"Id - {item.Id}, Adı - {item.Name}");
            }

        l3:

            modelId = Helper.ReadInt("Yeni model Id-sini daxil edin", " Xəta!!! Zəhmət olmasa yenidən daxil edin");
            var model = db.Models.FirstOrDefault(m => m.Id == modelId);
            if (model == null)
            {
                Console.WriteLine($"{modelId}-Id li model siyahıda yoxdur", "Zəhmət olmasa yenidən cəhd edin");
                goto l2;

            }
        l4:
            var march = Helper.ReadInt("Avtomobilin yürüşünü daxil edin!", "Səhv daxil etdiniz!");

            if (march < 0)
            {
                Console.WriteLine("Yürüş 0-dan az ola bilməz!");
                goto l3;
            }


            foreach (var item in Enum.GetValues(typeof(TypeOfFuel)))
            {
                Console.WriteLine($"{(int)item}-{item}");
            }

            TypeOfFuel typeOfFuel;

        l5:
            var typeOfFuelNum = Helper.ReadInt("Yanacaq növünü seçin:", "Səhv daxil etdiniz!");

            if (Enum.IsDefined(typeof(TypeOfFuel), typeOfFuelNum))
            {
                typeOfFuel = (TypeOfFuel)typeOfFuelNum;
            }

            else
            {
                Console.WriteLine("Səhv seçim etdiniz yeniden cəhd edin!");
                goto l4;

            }

            TypeOfGearBox typeOfGearBox;
        l6:
            foreach (var item in Enum.GetValues(typeof(TypeOfGearBox)))
            {
                Console.WriteLine($"{(int)item}-{item}");
            }
            var typeOfGearBoxNum = Helper.ReadInt("Sürətlər qutusunun növünü seçin:", "Səhv daxil etdiniz!");

            if (Enum.IsDefined(typeof(TypeOfGearBox), typeOfGearBoxNum))
            {
                typeOfGearBox = (TypeOfGearBox)typeOfGearBoxNum;
            }
            else
            {
                Console.WriteLine("Səhv daxil etdiniz yenidən cəhd edin!");
                goto l5;
            }

            TypeOfTransmission typeOfTransmission;

        l7:
            foreach (var item in Enum.GetValues(typeof(TypeOfTransmission)))
            {
                Console.WriteLine($"{item}-{item}");
            }
            var typeOfTransmissionNum = Helper.ReadInt("Ötürücü növünü seçin", "Səhv daxil etdiniz!");
            if (Enum.IsDefined(typeof(TypeOfTransmission), typeOfTransmissionNum))
            {
                typeOfTransmission = (TypeOfTransmission)typeOfTransmissionNum;
            }
            else
            {
                Console.WriteLine("Səhv daxil etdiniz yenidən cəhd edin!");
                goto l6;
            }

            TypeOfBan typeOfBan;
        l8:
            foreach (var item in Enum.GetValues(typeof(TypeOfBan)))
            {
                Console.WriteLine($"{item}-{item}");
            }
            var typeOfBanNum = Helper.ReadInt("Ban növünü seçin!", "Səhv daxil etdiniz! ");
            if (Enum.IsDefined(typeof(TypeOfBan), typeOfBanNum))
            {
                typeOfBan = (TypeOfBan)typeOfBanNum;
            }
            else
            {
                Console.WriteLine("Səhv daxil etdiniz yenidən cəhd edin!");
                goto l7;
            }

            announcement.Banner = typeOfBan;
            announcement.Transmission = typeOfTransmission;
            announcement.Price = price;
            announcement.GearBox = typeOfGearBox;
            announcement.FuelType = typeOfFuel;
            announcement.March = march;
            announcement.ModelId = modelId;
            announcement.LastModifiedAt = DateTime.Now;

            db.SaveChanges();

            foreach (var item in query.ToList())
            {
                Console.WriteLine($"Information: Id-{item.Id}, Ban növü-{item.Banner}, Yürüş - {item.March}" +
                  $" Sürətlər qutusu növü-{item.GearBox}, Yanacaq növü-{item.FuelType}, Modeli - {item.ModelName}" +
                  $" Marka-{item.BrandName}, Qiyməti-{item.Price}, Ötürücü növü-{item.Transmission}");
            }

            Console.WriteLine("Dəyişikliklər uğurla əlavə edildi ! \n");
        }
//NEW METHOD
        private static void DeleteAnnouncement()
        {
            var query = from m in db.Models
                        join b in db.Brands on m.BrandId equals b.Id
                        join c in db.CarAnnouncements on m.Id equals c.ModelId
                        select new
                        {
                            c.Id,
                            c.March,
                            c.Banner,
                            c.GearBox,
                            c.FuelType,
                            ModelName = m.Name,
                            BrandName = b.Name,
                            c.Price,
                            c.Transmission
                        };

            if (!query.Any())
            {
                Console.WriteLine("Elan siyahısı boşdur-Elan yoxdur");
                return;
            }
            foreach (var item in query.ToList())
            {
                Console.WriteLine($"Information: Id-{item.Id}, Ban növü-{item.Banner}, Yürüş - {item.March}" +
                  $" Sürətlər qutusu növü-{item.GearBox}, Yanacaq növü-{item.FuelType}, Modeli - {item.ModelName}" +
                  $" Marka-{item.BrandName}, Qiyməti-{item.Price}, Ötürücü növü-{item.Transmission}");
            }


        l1:
            int AnnouncementId = Helper.ReadInt("Elanın Id-sini daxil edin", "Səhv daxil etdiniz");
            var announcement = db.CarAnnouncements.FirstOrDefault(m => m.Id == AnnouncementId);
            if (announcement is null)
            {
                Console.WriteLine($"{AnnouncementId}-Idli elan tapılmadı ");
                goto l1;
            }

            db.CarAnnouncements.Remove(announcement);
            db.SaveChanges();
            Console.WriteLine("Elan uğurla silindi!\n");

        }
//NEW METHOD
        private static void AddAnnouncement()
        {
            int modelId;
            double price;
            int march;
            int typeOfFuelNum;
            int typeOfGearBoxNum;
            int typeOfTransmissionNum;
            int typeOfBanNum;

            var query = from m in db.Models
                        join b in db.Brands on m.BrandId equals b.Id
                        select new
                        {
                            m.Id,
                            m.Name,
                            m.BrandId,
                            BrandName = b.Name
                        };

            Console.WriteLine("Elan yaratmaq üçün modellərdən birini seçin!");

            foreach (var item in query.ToList())
            {
                Console.WriteLine($"Information: Id - {item.Id} Adi - {item.Name} Marka - {item.BrandName}");
            }

        l1:

            modelId = Helper.ReadInt("Modelin Id-sini daxil edin!", "Səhv daxil etdiniz!");
            var model = query.FirstOrDefault(m => m.Id == modelId);
            if(model is null)
            {
                Console.WriteLine("Seçdiyiniz Id-ilə model yoxdur! ");
             goto l1;
            }

        l2:

            price = Helper.ReadDouble("Qiyməti daxil edin!", "Səhv daxil etdiniz!");
            if (price < 100)
            {
                Console.WriteLine("Daxil etdiyiniz qiymət minimum qiymətdən aşağıdır");
                goto l2;
            }

        l3:
            march = Helper.ReadInt("Avtomobilin yürüşünü daxil edin", "Səhv daxil etdiniz");
            if(march < 0)
            {
                Console.WriteLine("Daxil etdiyiniz  yürüş 0-dan aşağı ola bilməz");
                goto l3;
            
             }


            foreach( var item in Enum.GetValues(typeof(TypeOfFuel)))
            {
                Console.WriteLine($"{(int)item}-{item}");
            }

            TypeOfFuel typeOfFuel;
        l4:

            typeOfFuelNum = Helper.ReadInt("Yanacaq növünü seçin", "Səhv daxil etdiniz");

            if(Enum.IsDefined(typeof(TypeOfFuel), typeOfFuelNum))
            {
                typeOfFuel=(TypeOfFuel)typeOfFuelNum;
            }
            else
            {
                Console.WriteLine("Səhv seçim etdiniz yenidən cəhd edin!");
                goto l4;
            }

            TypeOfGearBox typeOfGearBox;
        l5:

            foreach(var item in Enum.GetValues(typeof(TypeOfGearBox)))
            {
                Console.WriteLine($"{(int)item}-{item}");
            }
            typeOfGearBoxNum = Helper.ReadInt("Sürətlər qutusunun növünü seçin","Səhv daxil etdiniz");

            if (Enum.IsDefined(typeof(TypeOfGearBox), typeOfGearBoxNum))
            {
                typeOfGearBox=(TypeOfGearBox)typeOfGearBoxNum;
            }
            else
            {
                Console.WriteLine("Səhv seçim etdiniz yenidən cəhd edin!");
                goto l5;
            }

            TypeOfTransmission typeOfTransmission;
     
            foreach(var item in Enum.GetValues(typeof(TypeOfTransmission))) 
            { 
                Console.WriteLine($"{(int)item}-{item}");
            }
        l6:  
            typeOfTransmissionNum = Helper.ReadInt("Ötürücü növünü seçin", "Səhv daxil etdiniz");

            if(Enum.IsDefined(typeof(TypeOfTransmission), typeOfTransmissionNum))
            {
                typeOfTransmission=(TypeOfTransmission)typeOfTransmissionNum;   
            }
            else
            {
                Console.WriteLine("Səhv seçim etdiniz yenidən cəhd edin!");
                goto l6;
            }
        l7:
            TypeOfBan typeOfBan;
            foreach(var item in Enum.GetValues(typeof(TypeOfBan)))
            {
                Console.WriteLine($"{(int)item}-{item}");
            }
            typeOfBanNum = Helper.ReadInt(" Ban növünü seçin", "Səhv daxil etdiniz");

            if((Enum.IsDefined(typeof(TypeOfBan), typeOfBanNum)))
            {
                typeOfBan=(TypeOfBan)typeOfBanNum;
            }
            else
            {
                Console.WriteLine("Səhv seçim etdiniz yenidən cəhd edin!");
                goto l7;
            }

            Announcement announcement = new Announcement();
            announcement.Banner = typeOfBan;
            announcement.Transmission = typeOfTransmission;
            announcement.Price = price;
            announcement.GearBox = typeOfGearBox;
            announcement.FuelType = typeOfFuel;
            announcement.March = march;
            announcement.ModelId = modelId;
            announcement.CreatedAt = DateTime.Now;
            announcement.CreatedBy = 1;
            db.CarAnnouncements.Add(announcement);
            db.SaveChanges();

            Console.WriteLine($"Yeni elan uğürla əlavə olundu");
            Console.WriteLine($"Information: Id-{announcement.Id}, Ban növü - {announcement.Banner} Yürüş - {announcement.March}" +
                $"Sürətlər qutusu növü -{announcement.GearBox} Yanacaq növü - {announcement.FuelType} Modeli - {announcement.ModelId}" +
                $"Marka ");



        }
//NEW METHOD
        private static void EditModel()
        {
            int modelId;
            var query = from m in db.Models
                        join b in db.Brands on m.BrandId equals b.Id
                        select new
                        {
                            m.Id,
                            m.Name,
                            m.BrandId,
                            BrandName = b.Name,
                        };
            foreach ( var item in query.ToList()) 
            {
                Console.WriteLine($"id-{item.Id} Adı-{item.Name} Marka-{item.BrandName}");
            }

        l1:
            modelId = Helper.ReadInt(" Düzəliş etmək istədiyiniz modelin Id-sini daxil edin !", "Səhv daxil etdiniz");
            var model = db.Models.FirstOrDefault( x => x.Id == modelId );
            if ( model == null )
            {
                Console.WriteLine($"{modelId}-Id-li Model tapılmadı ");
                goto l1;
            }
            string newModelName = Helper.ReadString("Modelin yeni adını daxil edin", "Səhv daxil etdiniz");

            foreach( var item in query.ToList())
            {
                Console.WriteLine($"id-{item.Id} Adı-{item.Name} ");
            }
            int brandId;

        l2:
            brandId = Helper.ReadInt("Yeni markanın İd-sini daxil edin!", "Səhv daxil etdiniz");
            var brand = db.Models.FirstOrDefault(m=> m.Id == brandId);
            if ( brand == null)
            {
                Console.WriteLine($"{brandId}- Id li Marka siyahıda yoxdur!");
                goto l2;
            }
            model.BrandId = brandId;
            model.Name = newModelName;
            db.SaveChanges();
            Console.WriteLine("Dəyişikliklər uğurla əlavə edildi ! \n");

        }
//NEW METHOD
        private static void GetModelById()
        {
            int modelId;

            var query = from m in db.Models
                        join b in db.Brands on m.BrandId equals b.Id
                        select new
                        {
                            m.Id,
                            m.Name,
                            m.BrandId,
                            BranName = b.Name
                        };
  //niye burda join c elemirik

            foreach( var item in query )
            {
                Console.WriteLine($" Id-{item.Id}");
            }

        l1:
            modelId = Helper.ReadInt("Tapmaq istədiyiniz Modelin Id-sini daxil edin", "Səhv daxil etdiniz");
            var model = query.FirstOrDefault(x => x.Id == modelId);
            if( model == null )
            {
                Console.WriteLine("Bu Id-ilə model tapılmadı!");
                goto l1;
               
            }
            Console.WriteLine($"Id - {model.Id} Adı-{model.Name} Marka-{model.BranName}");
            Console.WriteLine("\n");
        }
//NEW METHOD
        private static void GetAllModels()
        {
            var query = from m in db.Models
                        join b in db.Brands on m.BrandId equals b.Id
                        select new
                        {
                            m.Id,
                            m.Name,
                            m.BrandId,
                            BranName = b.Name

                        };
            if(!query.Any())
            {
                Console.WriteLine("Model siyahısı boşdur");
                return;
            }
            foreach( var item in query.ToList())
            {
                Console.WriteLine($"Information Id-{item.Id} Marka-{item.BranName}");
            }
            Console.WriteLine("\n");
        }
//NEW METHOD
        private static void DeleteModel()
        {
            int deleteId;
            var query = from m in db.Models
                        join b in db.Brands on m.BrandId equals b.Id
                        select new
                        {
                            m.Id,
                            m.Name,
                            m.BrandId,
                            BrandName = b.Name
                        };
            Console.WriteLine();
            foreach( var item in query.ToList())
            {
                Console.WriteLine($"Id-{item.Id} Adı-{item.Name} Marka-{item.BrandName}");
            }
        l1:
            deleteId = Helper.ReadInt(" Silmək istədiyiniz Modelin Id - sini daxil edin", "Səhv daxil etdiniz");
            var model = db.Models.FirstOrDefault( m => m.Id == deleteId);
            if ( model is null ) 
            {
                Console.WriteLine("Xəta!!! Daxil etdiyiniz Id- ilə model mövcüd deyl!");
                goto l1;
            }
            db.Models.Remove( model );
            db.SaveChanges();
            Console.WriteLine("Uğurla silindi!\n");
        }
//NEW METHOD
        private static void AddNewModel()
        {
            if(!db.Models.Any())
            {
                Console.WriteLine("Marka siyahısı boşdur!Zəhmət olmasa Marka əlavə edin!");
                return;
            }

            string modelname = Helper.ReadString("Modelin adını daxil edin", "Səhv daxil etdiniz");
            int markaId;
            foreach( var item in db.Brands)
            {
                Console.WriteLine($"Id - {item.Id} Adı - {item.Name} "); 
            }

        l1:
            markaId = Helper.ReadInt("Modelin markasını daxil edin", "Səhv daxil etdiniz");
            var marka = db.Models.FirstOrDefault(m => m.Id == markaId);
            if ( marka is null )
            {
                Console.WriteLine("Səhv Id daxil etmisiniz");
                goto l1;
            }

            Models.Entities.Model model = new Models.Entities.Model();  
            model.BrandId = markaId;
            model.Name = modelname;
            model.CreatedAt = DateTime.Now;
            model.CreatedBy = 1;
            db.Models.Add( model );
            db.SaveChanges();
            Console.WriteLine("Uğurla əlavə edildi !\n");
        }
//NEW METHOD
        private static void EditMarka()
        {
            int markaId;
            foreach(Brand item  in db.Brands)
            {
                Console.WriteLine($"Id - {item.Id} Adı - {item.Name} ");
            }
        l1:
            markaId = Helper.ReadInt(" Düzəliş etmək istədiyiniz markanın Id-sini daxil edin !", "Səhv daxil etdiniz");
              Brand marka = db.Brands.FirstOrDefault(m => m.Id == markaId);
            if ( marka is null ) 
            {
                Console.WriteLine($"{markaId}-Id-li Marka tapılmadı");
                goto l1;
            }
            string NewMarka = Helper.ReadString("Düzəliş etmək istədiyiniz Markanın Id-sini daxil edin !", "Səhv daxil etdiniz!");
            marka.Name = NewMarka;
            Console.WriteLine("Dəyişikliklər uğurla əlavə edildi!!!\n");
            db.SaveChanges();
        }
//NEW METHOD
        private static void GetMarkaById()
        {
            int markaId = Helper.ReadInt("Tapmaq istədiyiniz Markanın Id-sini daxil edin", "Səhv daxil etdiniz");
            var marka = db.Brands.FirstOrDefault(x => x.Id == markaId);
            if (marka is null)
            {
                Console.WriteLine("Bu Id-ilə marka tapılmadı!");
                return;

            }
            Console.WriteLine($"Id - {marka.Id} Adı - {marka.Name} \n");
            Console.WriteLine("\n");
        }
//NEW METHOD
        private static void DeleteMarka() 
        {
            if (!db.Brands.Any())
            {
                Console.WriteLine("Marka siyahısı boşdur-Marka yoxdur!");
                return;
            }
            foreach (Brand item in db.Brands)
            {
                Console.WriteLine($" Id-{item.Id} Adı - {item.Name}");
            }


        l1:
            int markaId = Helper.ReadInt(" Markanın Id-sini daxil edin", "Səhv daxil etdiniz!");
            Brand marka = db.Brands.FirstOrDefault(m => m.Id == markaId);
            if (marka is null)
            {
                Console.WriteLine($"{markaId}-Id ilə marka tapılmadı ");
                goto l1;
            }

            db.Brands.Remove(marka);
            db.SaveChanges();
            Console.WriteLine("Marka uğurla silindi!\n");
        }
//NEW METHOD
        private static void GetAllMarka()
        {
            if (db.Brands.Any())
            { 
                foreach (var item in db.Brands)
                {
                    Console.WriteLine($"Id - {item.Id}, Adı - {item.Name}");
                }
            }
            else
            {
                Console.WriteLine("Marka siyahısı boşdur-Marka yoxdur!\n");
            }
            db.SaveChanges ();
        }
//NEW METHOD
        private static void AddNewMarka()
        {
            string markaName;
        l1:
            Console.WriteLine("Markanın adını daxil edin:");
            markaName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(markaName)||markaName.Length < 2)
            {
                Console.WriteLine("Marka adı boş buraxıla bilməz və ya marka adı ən azı 2 simvoldan ibarət olmalıdır!!!");
                goto l1;
            }
            Brand marka = new Brand()
            {
                Name = markaName,
            };
            marka.CreatedAt = DateTime.Now;
            marka.CreatedBy = 1;

            db.Brands.Add(marka);
            db.SaveChanges();
            Console.WriteLine("Marka uğurla əlavə edildi !\n");
        }



    }
}
    
