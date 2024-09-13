using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace deneme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bakiye = 2500;
            string sifre = "10";
            int sifreDenemeSayisi = 0;
            Console.WriteLine(" HOŞGELDİNİZ ");

            try
            {


                while (sifreDenemeSayisi < 3)
                {

                    Console.WriteLine(" \n*****İŞLEMLER*****\n ");
                    Console.WriteLine("Kartlı işlem için: 1");
                    Console.WriteLine("Kartsız işlem için: 2");
                    string islemSecim = Console.ReadLine();
                    Console.Clear();

                    if (islemSecim == "1")
                    {
                        Console.Write("Şifre: ");
                        string girilenSifre = Console.ReadLine();

                        if (girilenSifre == sifre)
                        {
                            Console.WriteLine("Şifre doğru. Ana Menüye yönlendiriliyorsunuz... ");
                            Thread.Sleep(1000);
                            Console.Clear();
                            break;
                        }
                        else
                        {

                            sifreDenemeSayisi++;
                            if (sifreDenemeSayisi == 3)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Şifreniz 3 defa yanlış girildi. Sistemden atılıyorsunuz.");
                                Thread.Sleep(2000);
                                return;
                            }
                            else
                            {

                                Console.WriteLine("Şifre yanlış. Kalan deneme hakkınız: {0}", 3 - sifreDenemeSayisi);
                            }
                        }
                    }
                    else if (islemSecim == "2")
                    {

                        Console.WriteLine("Kartsız işlem menüsü arızalı!");
                        Console.WriteLine("\nAna menu için her hangi bir tuşa basın");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {

                        Console.WriteLine("Hatalı seçim yaptınız");
                        Console.WriteLine("\nAna menu için her hangi bir tuşa basın");
                        Console.ReadKey();
                        Console.Clear();
                    }

                }
                while (true)
                {
                    Console.WriteLine("*******************Ana Menü****************");
                    Console.WriteLine("Para Çekmek için:\t1");
                    Console.WriteLine("Para yatırmak için:\t2");
                    Console.WriteLine("Para Transferleri:\t3");
                    Console.WriteLine("Eğitim Ödemeleri:\t4");
                    Console.WriteLine("Fatura Ödemeleri:\t5");
                    Console.WriteLine("Bilgi Güncelleme:\t6");


                    int anaMenuSecim = 0;
                    try
                    {

                        anaMenuSecim = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Geçersiz bir giriş yaptınız. Lütfen bir sayı girin.");
                        Console.Clear();
                        continue;
                    }

                    switch (anaMenuSecim)
                    {
                        case 1:
                            Console.WriteLine("Bakiye: {0} TL", bakiye);
                            Console.WriteLine("Para çekmek için: 1");
                            Console.WriteLine("**************************");
                            Console.WriteLine("Ana menüye dönmek için: 9");
                            Console.WriteLine("Çıkmak için: 0");
                            Console.WriteLine("**************************");

                            int paraCekSecim = Convert.ToInt32(Console.ReadLine());

                            if (paraCekSecim == 1)
                            {

                                Console.Write("Çekilecek miktarı girin: ");
                                int cekilecekMiktar = 0;

                                try
                                {
                                    cekilecekMiktar = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (FormatException)
                                {

                                    Console.Clear();
                                    Console.WriteLine("Geçersiz bir giriş yaptınız. Lütfen bir sayı girin.");
                                    continue;
                                }

                                if (cekilecekMiktar > bakiye)
                                {
                                    Console.Clear();

                                    Console.WriteLine("Yetersiz bakiye. Ana Menüye yönlendiriliyor..");
                                    Thread.Sleep(1500);
                                    Console.Clear();


                                }
                                else
                                {
                                    Console.Clear();
                                    bakiye -= cekilecekMiktar;
                                    Console.WriteLine("{0} TL çekildi. Yeni bakiye: {1} TL", cekilecekMiktar, bakiye);
                                }
                            }
                            else if (paraCekSecim == 9)
                            {

                                continue;
                            }
                            else if (paraCekSecim == 0)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Çıkış yapılıyor lütfen bekleyiniz...");
                                Thread.Sleep(1000);
                                return;
                            }
                            break;


                        case 2:

                            Console.WriteLine("Kredi Kartına: 1");
                            Console.WriteLine("Kendi Hesabınıza yatırmak için: 2");
                            Console.WriteLine("**************************");
                            Console.WriteLine("Ana menüye dönmek için: 9");
                            Console.WriteLine("Çıkmak için: 0");
                            Console.WriteLine("**************************");
                            int paraYatirmaSecim = 0;

                            try
                            {
                                paraYatirmaSecim = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                            }
                            catch (FormatException)
                            {

                                Console.WriteLine("Geçersiz bir giriş yaptınız. Lütfen bir sayı girin.");
                                continue;
                            }

                            if (paraYatirmaSecim == 1)
                            {
                                Console.Write("Kredi kartı numarasını girin (en az 12 haneli): ");
                                string kartNumarasi = Console.ReadLine();

                                if (kartNumarasi.Length < 12)
                                {
                                    Console.WriteLine("Hatalı kart numarası girişi.");
                                }
                                else
                                {
                                    Console.Write("Yatırılacak miktarı girin: ");
                                    int yatirilacakMiktar = int.Parse(Console.ReadLine());
                                    Console.Clear();
                                    bakiye -= yatirilacakMiktar;
                                    Console.WriteLine("{0} TL kredi kartına yatırıldı. Yeni bakiye: {1} TL", yatirilacakMiktar, bakiye);
                                    continue;
                                }
                                int a2;
                                Console.WriteLine("Ana menüye dönmek için: 9");
                                Console.WriteLine("Çıkmak için: 0");

                                a2 = Convert.ToInt32(Console.ReadLine());

                                if (a2 == 0)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Çıkış yapılıyor lütfen bekleyiniz...");
                                    Thread.Sleep(1000);
                                    return;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.Write(paraYatirmaSecim);
                                }
                            }

                            if (paraYatirmaSecim == 9)
                            {
                                continue;
                            }


                            else if (paraYatirmaSecim == 2)
                            {
                                Console.Write("Yatırılacak miktarı girin: ");
                                int yatirilacakMiktar = int.Parse(Console.ReadLine());

                                bakiye += yatirilacakMiktar;
                                Console.WriteLine("{0} TL hesaba yatırıldı. Yeni bakiye: {1} TL", yatirilacakMiktar, bakiye);

                            }
                            else if (paraYatirmaSecim == 9)
                            {
                                goto case 2;
                            }
                            else if (paraYatirmaSecim == 0)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Çıkış yapılıyor lütfen bekleyiniz...");
                                Thread.Sleep(1000);
                                return;
                            }
                            break;

                        case 3:
                            Console.WriteLine("Başka Hesaba EFT: 1");
                            Console.WriteLine("Başka Hesaba HAVALE: 2");
                            Console.WriteLine("**************************");
                            Console.WriteLine("Ana Menüye dönmek için: 9");
                            Console.WriteLine("Çıkmak için: 0");
                            Console.WriteLine("**************************");

                            int cevap = Convert.ToInt32(Console.ReadLine());

                            if (cevap == 1)
                            {


                                Console.WriteLine("\n**********EFT Yap**********");

                                Console.Write("EFT numarası (tr ile başlayan 12 haneli): ");
                                string iban = Console.ReadLine().ToLower();



                                if (iban.Length == 14 && iban.StartsWith("tr") && long.TryParse(iban.Substring(2), out _))
                                {
                                    Console.Write("Yatırmak istediğiniz miktarı girin: ");
                                    int yatirilacakMiktar = int.Parse(Console.ReadLine());


                                    if (yatirilacakMiktar > 0 && yatirilacakMiktar <= bakiye)
                                    {
                                        Console.Clear();
                                        bakiye -= yatirilacakMiktar;
                                        Console.WriteLine("EFT işlemi gerçekleştirildi. Yeni bakiye: " + bakiye + " TL");

                                    }
                                    else
                                    {
                                        Console.WriteLine("Yetersiz bakiye. İşlem gerçekleştirilemedi.");
                                    }

                                }
                                else if (cevap == 9)
                                {
                                    continue;
                                }
                                else if (cevap == 0)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Çıkış yapılıyor lütfen bekleyiniz...");
                                    Thread.Sleep(1000);
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("İban girişi hatalı, Ana menüye yönlendiriliyor..");
                                    Thread.Sleep(1500);
                                    Console.Clear();
                                }
                                break;
                            }
                            else if (cevap == 2)
                            {
                                Console.Clear();
                                Console.WriteLine("**********HAVALE Yap**********");

                                Console.Write("havale numarası ( 11 haneli): ");
                                string havale = Convert.ToString(Console.ReadLine());

                                if (havale.Length == 11)
                                {
                                    Console.Write("Yatırmak istediğiniz miktarı girin: ");
                                    int yatirilacakMiktar = int.Parse(Console.ReadLine());

                                    if (yatirilacakMiktar > 0 && yatirilacakMiktar <= bakiye)
                                    {
                                        Console.Clear();
                                        bakiye -= yatirilacakMiktar;
                                        Console.WriteLine("HAVALE işlemi gerçekleştirildi. Yeni bakiye: " + bakiye + " TL");

                                    }
                                    else
                                    {
                                        Console.WriteLine("Yetersiz bakiye. İşlem gerçekleştirilemedi.");
                                    }

                                }
                                else if (anaMenuSecim == 9)
                                {
                                    continue;
                                }
                                else if (cevap == 0)
                                {

                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Havale numarası girişi hatalı, Ana menüye yönlendiriliyor..");
                                    Thread.Sleep(1500);
                                    Console.Clear();
                                }
                                break;
                            }
                            if (cevap == 0)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Çıkış yapılıyor lütfen bekleyiniz...");
                                Thread.Sleep(1000);
                                return;
                            }
                            break;




                        case 4:
                            Console.WriteLine("Eğitim ödemeleri bölümü arızalıdır");
                            Console.WriteLine("*****************");
                            Console.WriteLine("Ana Menü: 9");
                            Console.WriteLine("Çıkmak için: 0");
                            Console.WriteLine("*****************");
                            try
                            {
                                anaMenuSecim = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Geçersiz bir giriş yaptınız. Lütfen bir sayı girin.");
                            }

                            if (anaMenuSecim == 9)
                            {
                                continue;

                            }

                            else if (anaMenuSecim == 0)
                            {
                                return;
                            }
                            break;
                        default:
                            Console.WriteLine("Hatalı seçim yaptınız");
                            Console.WriteLine("Ana menuye yönlendiriyorsunuz...");
                            Thread.Sleep(2000);
                            Console.Clear();
                            break;

                        case 5:

                            Console.WriteLine("Elektrik Faturası: 1");
                            Console.WriteLine("Telefon Faturası: 2");
                            Console.WriteLine("İnternet faturası: 3");
                            Console.WriteLine("Su Faturası: 4");
                            Console.WriteLine("Ogs Ödemeleri: 5");
                            Console.WriteLine("***************");
                            Console.WriteLine("Ana Menü: 9");
                            Console.WriteLine("Çıkmak için: 0");
                            Console.WriteLine("***************");

                            int fatura = Convert.ToInt32(Console.ReadLine());


                            if (fatura == 1)
                            {
                                Console.Clear();
                                Console.Write("Yatırmak istediğiniz miktarı girin: ");
                                int yatirilacakMiktar = int.Parse(Console.ReadLine());

                                if (yatirilacakMiktar > 0 && yatirilacakMiktar <= bakiye)
                                {
                                    bakiye -= yatirilacakMiktar;
                                    Console.WriteLine("Fatura yatırma işlemi gerçekleştirildi. Yeni bakiye: " + bakiye + " TL");
                                }
                                else
                                {
                                    Console.WriteLine("Yetersiz bakiye. İşlem gerçekleştirilemedi.");
                                }
                            }
                            else if (fatura == 2)
                            {
                                Console.Clear();
                                Console.Write("Yatırmak istediğiniz miktarı girin: ");
                                int yatirilacakMiktar = int.Parse(Console.ReadLine());

                                if (yatirilacakMiktar > 0 && yatirilacakMiktar <= bakiye)
                                {
                                    bakiye -= yatirilacakMiktar;
                                    Console.WriteLine("Fatura yatırma işlemi gerçekleştirildi. Yeni bakiye: " + bakiye + " TL");
                                }
                                else
                                {
                                    Console.WriteLine("Yetersiz bakiye. İşlem gerçekleştirilemedi.");
                                }
                            }
                            else if (fatura == 3)
                            {
                                Console.Clear();
                                Console.Write("Yatırmak istediğiniz miktarı girin: ");
                                int yatirilacakMiktar = int.Parse(Console.ReadLine());

                                if (yatirilacakMiktar > 0 && yatirilacakMiktar <= bakiye)
                                {
                                    bakiye -= yatirilacakMiktar;
                                    Console.WriteLine("Fatura yatırma işlemi gerçekleştirildi. Yeni bakiye: " + bakiye + " TL");
                                }
                                else
                                {
                                    Console.WriteLine("Yetersiz bakiye. İşlem gerçekleştirilemedi.");
                                }
                            }
                            else if (fatura == 4)
                            {
                                Console.Clear();
                                Console.Write("Yatırmak istediğiniz miktarı girin: ");
                                int yatirilacakMiktar = int.Parse(Console.ReadLine());

                                if (yatirilacakMiktar > 0 && yatirilacakMiktar <= bakiye)
                                {
                                    bakiye -= yatirilacakMiktar;
                                    Console.WriteLine("Fatura yatırma işlemi gerçekleştirildi. Yeni bakiye: " + bakiye + " TL");
                                }
                                else
                                {
                                    Console.WriteLine("Yetersiz bakiye. İşlem gerçekleştirilemedi.");
                                }
                            }
                            else if (fatura == 5)
                            {
                                Console.Clear();
                                Console.Write("Yatırmak istediğiniz miktarı girin: ");
                                int yatirilacakMiktar = int.Parse(Console.ReadLine());

                                if (yatirilacakMiktar > 0 && yatirilacakMiktar <= bakiye)
                                {
                                    bakiye -= yatirilacakMiktar;
                                    Console.WriteLine("Fatura yatırma işlemi gerçekleştirildi. Yeni bakiye: " + bakiye + " TL");
                                }
                                else
                                {
                                    Console.WriteLine("Yetersiz bakiye. İşlem gerçekleştirilemedi.");
                                }
                            }
                            if (fatura == 0)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Çıkış yapılıyor lütfen bekleyiniz...");
                                Thread.Sleep(1000);
                                return;
                            }
                            else
                            {

                                continue;

                            }



                        case 6:

                            Console.WriteLine("Şifre değiştirmek için: 1");
                            Console.WriteLine("*****************");
                            Console.WriteLine("Ana Menü için: 9");
                            Console.WriteLine("Çıkış için: 0");
                            Console.WriteLine("*****************");
                            int sifresecim = Convert.ToInt32(Console.ReadLine());


                            if (sifresecim == 1)
                            {
                                Console.WriteLine("Lütfen şuanki Şifrenizi giriniz:");
                                Console.WriteLine("********************************");
                                string sifre2 = Console.ReadLine();

                                if (sifre2 == sifre)
                                {
                                    Console.WriteLine("Lütfen yeni şifrenizi giriniz");
                                    Console.ReadLine();
                                    sifre = sifre2;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Şifre başarı ile güncellendi!");

                                }
                                else
                                {
                                    Console.WriteLine("Şifre hatalı!");
                                }





                            }

                            if (sifresecim == 0)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Çıkış yapılıyor lütfen bekleyiniz...");
                                Thread.Sleep(1000);
                                return;
                            }

                            if (sifresecim == 9)
                            {
                                Console.Clear();
                            }


                            break;
                    }




                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }


    }

}




