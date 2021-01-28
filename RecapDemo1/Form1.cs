using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//AÇIKLAMALAR..
//Windows Froms App (.NET Framework) ile oluşturduk..
//8 satır 8 sütunlu bir dama tahtasıyapacağız..
//Sol tarafta "Tool Box" ı aç ve sabitle..
//Common Controls - Button 8x8 toplam 64 tane buton yerleştirmemiz gerekir..
//Ya bu şekilde tek tek elle yerleştireceğiz ya da uygulama açıldığında otomatik olarak eklesin diye kod yazacağım..
//Beyaz ekran sol üstteki Form1'e 2 kere tıkla burası açılacak (Form1'in kod kısmı)..
//Butonlar aslında classtır.. yani 64 calass gerekiyor..




namespace RecapDemo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // Button button = new Button();   //Button nesnesini oluşturduk..

            //button.Width = 50;
            //button.Height = 50;             //Bu yükseklik ve genişlikteki butonu oluşturdu..
            //button.Text = "My button";      //Butonun içine bunu yazdı.. Örnek amaçlıydı, comment yaptım..
            //this.Controls.Add(button);      //Bu butonu ekrana koy demek..

            //bana 64 tane buton lazım ya bu butonları aynı yukarıdaki gibi 64 tane yazacağız ya da döngü yapabiliriz..(for..)
            //ancak for ile alt üst sınırını yazıp döngülediğimizde butonlar alt alta görünecektir..
            //en iyisi array ile çalışmak..

           

            GenerateButtons(); 

        }


        //--------------------------------------
        private void GenerateButtons()
        {
            Button[,] buttons = new Button[8, 8];       //1. paranteze virgül koymadan 2. paranteze direk 64 de yazabilirdik ama bu şekilde kontol etmesi kolay olcak.. Mesela; 3. satırın 3. butonu dediğimizde anında erişiriz..
            int top = 0;        //bunların açıklaması, ne olduğu satır 65-66 ve 67 da.. bunu yazdığımız için satır 60'ı yazabildik..
            int left = 0;


            //her satır için 8 tane döngü tasarlamam lazım(1. satır için 8 tane, 2. satır için 8 tane vs vs..) (for döngüsü)

            for (int i = 0; i <= buttons.GetUpperBound(0); i++)      //buttons.GetUpperBound = butonların 0. boyutunun alabileceği en yüksek değer.. şimdi 8 satır var ama eleman boyutları sayılırken 0'dan başlıyordu, unutma.. Bu yüzden burada maksimum 7 olabilir.. (0.-1.-2.-3.-4.-5.-6. ve 7. satır toplam 8 satır)
            {       //burda 8 satır için bir değer oluşturdum bide her satır için 8 buton daha oluşturmam lazım.. parantez içine for döngüsü ile onu yapalım..

                for (int j = 0; j <= buttons.GetUpperBound(1); j++)      //i=0 iken j=0 yani 0'a 0. buton (sıfırıncı satırın sıfırıncı yani aslında birinci butonu, ilk buton) //j=1 olunca sıfırıncı satırın 2. butonu vs vs.. sonunda j=7 sıfırıncı satırın 8. butonu olur ve bu satır biter..
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Width = 50;
                    buttons[i, j].Height = 50;      //50ye 50lik buton oluşturdum..
                    buttons[i, j].Top = top;        //ilk satırdaki 8 buton için top değeri 0 olacak ki en üstte kalsınlar.. (Bu şekliyle 0 demektir)
                    buttons[i, j].Left = left;         //Form1de başlangıç noktassından yani soldan uzaklığı demektir.. şu anda 0.. ancak 2. butonun görülmesi için lefti 50 karakter arttırmam lazım:
                    left += 50;                         //şimdi bunu da yazınca başta üst üste olan 64 buton şimdi yan yanadır..
                    this.Controls.Add(buttons[i, j]); //Bu butonu ekrana koy demek, bunu her bir butona uygulayacağız.. this dediği form1'e karşılık gelir, onu gösterir..

                    //bu işlemden sonra çalıştırdığımızda tek buton çıkmış gibi görünebilir ama üst üste eklenmiş 64 buton vardır.. 
                    //Bu yüzden mesela ilk butonu koyduktan sonra ikinci butonu sağa doğru 50 karakterden sonra başlatmam gerekiyor..
                    //bu yüzden satır 46 ve 47de top ve left değerlerini ekledik..


                    //şimdi dama tahtası olduğu için bir buton beyaz bir buton siyah yapalım..

                    if ((i + j) % 2 == 0)
                    {
                        buttons[i, j].BackColor = Color.Black;          //eğer i+j nin mod2 si eşit eşittir 0 ise o zaman buttons[i,j] nin back color ı eşittir siyaha..
                    }

                    else
                    {
                        buttons[i, j].BackColor = Color.White;          //değilse arka plan rengini beyaz yap..
                    }

                }

                top += 50; //şimdi bunu yazmadan önce 1 satırda 8 buton var gibi görünüyordu ancak 64 butonun geri kalanları onun arkasında kalmıştı..
                           //Bu sebeple şimdi top değerini 50 birim arttırdık ve altta kalanlar 50 ve katları şekilde dizildi... ilk satır için 50, ikinci için 100, üçüncü için 150 gibi.. (aynı şey lefte kaymada da olmuştu..)

                //şimdi satırlar bitti.. ikinci satırda lefti sıfırlamam lazım ki 2. satıra geçtiğimde sola geçsin..
                left = 0;

            }
            //--------------------------------------------

            //iki ----- arasını seçtim sol kenarda çıkan fırçaya tıkla Extract Method, Name: GenerateButtons(Buton oluştur).. Bunu da bir metot haline getirmiş olduk..

            //Çalıştır bak çoksel oldu :))))

        }
    }
}
