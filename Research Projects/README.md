<h1>Blazor Nedir?</h1>
<img src= "https://blog.christian-schou.dk/content/images/2022/08/How-To-Build-A-Blazor-Web-App.png" >
Blazor, C# kullanarak Single Page Application (SPA) oluşturmanıza ve tarayıcıda herhangi bir standart .NET kitaplığını çalıştırmanıza izin veren bir çerçevedir. Blazor'dan önce bir SPA oluşturmak için kullanılan seçenekler JavaScript kullanan Angular, React, Vue.js (ve diğerleri) veya TypeScript gibi (zaten JavaScript'te derlenen) diğer üst düzey dillerden biri olarak karşımıza gelmekteydi. Microsoft tarafından bakarsak, .NET web uygulamalarının şu an halen üzerinde çalışılan Blazor adında bir .NET web framework’ü ile, bildiğimiz browser üzerinde çalıştırılmasıdır. Kısaca backend’e gerek kalmadan, frontend tarafta yazılan C# kodlarının browser tarafında derlenip çalıştırılmasıdır. Yani; Blazor WebAssembly altında çalışan, .NET’te yazılmış tarayıcı tabanlı (istemci tarafı) uygulamalar için bir frameworkdür. Developerlara, sunucu ve istemci arasında kullanılan tüm.Net kodlarını browser üzerede uçtan uca kullanmamıza olanak verir. Ayrıca aynı Angular ve React’da olduğu gibi SinglePageApplication(SPA) platformunun tüm avantajlarını bize sunar. WebAssembly ile ilgili bir diğer şey ise, Browser’ın çalıştırıldığı zaman kodlarda late-binding’e izin verilmesidir. Yani farklı modüller birleşerek bir uygulama oluşturabilir. Örneğin önceden hazırlanmış standart bir modül, başka bir modül içerisine referans verilerek kullanılabilir.

<h1>Server App ve WebAssembly App Nedir?</h1>
<img src= "https://i0.wp.com/thecodeblogger.com/wp-content/uploads/2022/09/Blazor-Getting-Started.jpg?fit=1200%2C800&ssl=1">
Server App bizim için olayın serverda gerçekleştiğidir yani olay server side(sunucu tarafı) bir uygulama gibi düşünebiliriz. Bir server’da istekler yapıldığında o client için html render ediliyor ve client’a veriliyor. Bu işlemi ASP.NET gibi düşünebiliriz.
WebAssembly App ise aslında bizim için SPA(Single Page Application)lara benziyor. Yani modern Angular, React nasıl çalışıyorsa Blazor WebAssembly olarak çalıştığımızda aynı mantık ile çalışıyor.
Konular hemen hemen aynıdır. Sadece çalıştırma ortamına yönelik configuration ve bir takım değişiklikler dışında birini yapmamız arasında fark yoktur.

<h1>Memento Design Pattern Nedir? </h1>
<img src= "https://miro.medium.com/max/1200/1*firqUPZL5NJkWJoxp1QUHQ.png">
Memento kelime anlamı ile "hatıra" demektir. Memento pattern ise "hatıra kalıbı" olarak düşünülebilir. Memento Pattern, Behavioral Patterns yani "Davranışsal Kalıplar" kategorisinde yer alan bir kalıp türüdür. Yazılım dilinde memento patterni basitçe düşünmek ve anlatmak gerekirse hatırlayıcı işlevde bir tasarım olarak tanımlayabiliriz. Bir nesnenin başlangıç ve T anlarındaki durumunu kayda alarak ilerleyen aşamada bu nesne üzerinde yaptığımız değişiklikleri geri alarak kontrol etmemizi ve incelememizi sağlayan bir sistem olarak algılayabiliriz.Bir uygulamanın yaşam döngüsü boyunca, bir nesnenin durumu değişebilir. Daha sonra almak için mevcut durumun bir kopyasını saklamak isteyebilirsiniz. Örneğin, bir belge yazarken mevcut durumu her 10 dakikada bir otomatik olarak kaydetmek isteyebilirsiniz veya bir oyununuz var ve bu oyunda oyuncunuzun seviyedeki mevcut konumunu, skoru ve mevcut envanteri ile kaydetmek isteyebilirsiniz. İşte böyle durumlarda durumun bir kopyasını kaydetmek ve gerekirse daha sonra geri almak için Memento kalıbını kullanabilirsiniz. Memento Patern, Command Pattern gibi, uygulamanızda UNDO/REDO işlevselliğini uygulamak için de yaygın olarak kullanılır. UNDO/REDO için kullanılan bu Command ve Memento kalıpları arasındaki fark ise, Command Design Pattern, bir isteği kendisi ile ilgili tüm bilgileri içeren bağımsız bir nesneye dönüştüren davranışsal bir tasarım desenidir. Bu dönüşüm, istekleri metot parametresi olarak göndermenize, işlenmelerini geciktirmenize ya da sıraya sokmanıza ve geri alınamaz işlemleri desteklemenize olanak verir. Memento Design Pattern ise bir nesnenin önceki durumunu, uygulama detaylarını açığa çıkartmadan kaydetmeniz ve geri getirmenizi sağlayan bir tasarım desenidir.
UML diyagramı göz önüne alındığında; 
 
<img src="https://miro.medium.com/v2/resize:fit:640/format:webp/1*Te7g0EHylsotgYcWkrE2Ew.png"> 
 
(UML, bir programlama dili değil yazılım geliştirme için kullanılan standart bir diyagram çizme ve ilişkisel modelleme dilidir. Yazılım sistemlerinin nasıl modellenebileceğini belirleyen ve açıklayan yöntemlerin bir araya toplanmış halidir.) 
Originator, CareTaker ve Memento kavramları göze çarpmaktadır. 

<b>- Originator :</b> Ara sıra değişen dahili bir duruma sahip bir nesnedir. Yaratıcı, mucit, üretken olarak ifade edebileceğimiz bu nesne kopyası saklanacak olan nesneyi ifade etmektedir. Bu nesne, kendi kopyasının oluşturulmasından sorumlu olduğu gibi geri yüklenmesinden de sorumludur.

<b>- Caretaker :</b> Originator'dan Mementos'u yaratmasını veya geri yüklemesini isteyen bir sınıftır. Bakıcı daha sonra onları bir önbelleğe veya hatıra deposuna kaydeder. Bakıcı olarak nitelendirilen bu nesne, Memento referansını barındırmakta ve yapılacak tüm işlemlerin organizasyonunu sağlamaktadır.

<b>- Memento :</b> Oluşturanın dahili durumunun, daha sonra mevcut durumunu değiştirmek üzere oluşturana geri yüklenebilen bir kopyasıdır. Kopyalanacak nesnenin hangi özelliklerinin tutulacağı, bir başka deyişle hangi değerlerinin işleneceğini belirttiğimiz nesnedir.

<h1>Object Oriented Programming (OOP) Nedir?</h1>
<img src="https://iou.ac/wp-content/uploads/2021/07/Object-Oriented-Programming-1.png"> 
Object Oriented Programming diğer adı ile Nesne Yönelimli Programlama; yazılım tasarımını işlevler ve mantık yerine, veri veya nesneler etrafında düzenleyen bir programlama dili modelidir. Günümüzde yazılım geliştirme teknolojilerinde büyük önem taşımaktadır. OOP dendiğinde her işlevin nesnel olarak soyutlandığı bir programlama şeklidir. Bu yöntemi günlük hayatımıza uyarlarsak dolaplarımızdaki kıyafetlerimizi rengi, türü, ham maddes vb. gibi özelliklere göre ayırmak ve kullanmak istediğimizde daha kolay bulmak gibi düşünebilirsiniz. Bu durumu yazılım geliştirme için düşündüğümüzde, yazılımların karışık olması ve boyutlarının artması belirli bir nitelik düzeyini korumak için gereken maliyeti, zamanı ve çabayı arttırır. OOP yöntemi ile bu sorunların önüne geçmek amaçlanmıştır ve yöntem başarılı olmuştur. 

<h2>OOP Yönteminin Faydaları</h2>
Nesne oluşturma bir sınıf içerisinde toplanır ve tüm projelerde kullanılabilirliğe olanak sağlar.
Sınıfların 1 kez oluşturulması sayesinde uzun kodları tekrardan yazmak yerine kısa kodlamalar ile çalıştırılabilir.
Uzun kodların tekrar yazılmasının engellenmesi sayesinde geliştirme süreci kısalır.
Nesneler birbirinden bağımsız olduğundan bilgi gizliliği konusunda avantaj sağlar.
Sınıflar sayesinde tüm projelerde değişiklik yapmak yerine tek bir sınıfta değişiklik yapılıp tüm projelerde çalışması sağlanır. Bu zaman kaybını büyük ölçüde azaltır.
Kodların okunabilirliği artar.

<h2>OOP Sınıf (Class) Nedir ?</h2>
Sınıflar değişkenleri ve methodları saklayan sistemlerdir. Bunu giysi dolabı örneğimizden hareketle dolap içinde bölünmüş raflar gibi düşünebilirsiniz. Sınıfların içerisindeki değişkenler kullanacağımız verileri saklar. Methodlar ise sınıflar içerisinde yazılmış olan fonksiyonlardır. Veri saklama veya veri toplama görevini üstlenen sistemlerdir. 

<h2>OOP Nesne (Object) Nedir ?</h2>
Doğada yer alan her şey birer nesnedir. Evimizden sokakta gördüklerimize kadar her şeyi nesne olarak düşünebiliriz. Bu durumu teorik anlamda düşünecek olursak bir şeyi nesne olarak tanımlayabilmemiz için içerisinde durum ve davranış barındırması gereklidir. Yani nesneler verileri saklayan ve bu veriler üzerinde işlem yapan metodları saklayan bileşenlerdir. 

<h2>OOP C# OOP'nin Özellikleri Nelerdir ?</h2>
<img src="https://emrecelen.com.tr/wp-content/uploads/2021/04/c-oop-kavrami.png">
Ticari bir işletme düşünelim. C# OOP kavramına göre bu işletme programlarımızda oluşturmuş olduğumuz sınıflara karşılık gelir. Sınıf içerisindeki özelliklerimiz, tanımlamalarımız ise o işletmenin çalışanlarını oluşturur. Bu çalışanlarda nesneye karşılık gelir. Sonuç olarak çalışanların birbirleri ile uyumlu ve organize bir şekilde etkileşim içerisinde bulunmaları C# OOP kavramını ortaya çıkartır.

<h3>C# Abstraction (Soyutlama)</h3>
Bir sınıfın özelliklerinin ve davranışlarının tanımlanmasına denir. Örneğin bir telefon markasını ele alalım. Telefon burada bir sınıfa karşılık gelmektedir. Telefonun işletim sistemi özellikleri, hafızası, rengi, modeli, üretim yılı gibi kavramlar özelliklerini anlatırken örneğin fotoğraf çekim kalitesi, bazı uygulamaları kullanım sırasındaki performansı, aramalardaki ses kalitesi vb. özellikler ise davranış yapılarını tanımlar ve bunları abstract methodlar ile gerçekleştiririz.

<h3>C# Encapsulation (Kapsülleme)</h3>
Encapsulation(Kapsülleme) kavramını günlük hayattan ele alacak olursak, özel hayatımızda sahip olduğumuz her alışkanlığı veya davranışı dış dünyaya tamamen yansıtmayız veya çok az bir kısmını yansıtırız. Örneğin bir arkadaşınızla veya sevdiğiniz biriyle sorun yaşadığınızı düşünün. Bu durumu tüm ortak çevrenize doğrudan yansıtmazsınız. Kısıtlı bir kısmı hakkında bilgi verirsiniz. Kapsülleme kavramıda programlar içerisinde aynı mantıkta çalışmaktadır. Aynı şekilde programlarımızda tanımladığımız sınıftaki özellik ve davranışları kapsülleme kullanarak dışarıya sunumunu kısıtlayabiliriz. Bu noktada erişim seviyelerinin çalışma mantığını iyi anlamak gerekmektedir. Aşağıdaki resimde yukarıdan aşağı gidildikçe (Private -> Public ) erişim kolaylaşırken aşağıdan yukarı doğru gidildiğinde (Public -> Private) erişim zorlaşmaktadır. Şimdi bu kavramları biraz detaylandıralım. 
<img src="https://www.kodkampusu.com/wp-content/uploads/2021/04/KAPSULLEME-ERISIM-SEVIYESI.png">

<h4>Private:</h4>
Bir "özellik (property)"in veya "method"un sadece tanımlandığı sınıftan erişilebilmesini sağlar. Oluşturulan sınıf veya yapıların "public" olması açık bir şekilde belirtilmez ise, derleyici tarafından "private" olarak belirlenir.

<h4>Default:</h4>
Pakete özel anlamına gelir. Bu erişim belirleyicisi ile işaretlenen herşey sadece ve sadece aynı paket içerisinde tanımlanan sınıflar tarafından erişilebilir. Farklı paketlerde bulunan sınıflar erişemez.

<h4>Protected:</h4>
Sadece tanımlandığı sınıfın içinde ve o sınıftan türetilmiş diğer sınıfların içinde erişilebilir.

<h4>Public:</h4>
Sistemdeki bütün sınıfların erişebilmesini sağlar. Yalnızca aynı proje içinden değil, diğer projelerden de erişim sağlanabilir.

<h3>C# Inheritance (Miras Alma / Kalıtım)</h3>
Inheritance kavramını anlamak için örneğin Apple şirketini düşünelim. Bu tür büyük şirketlerin genelde farklı illerde ve hatta farklı ülkelerde bayileri bulunur. Bu bayiler ana şirkete bağlı ve ana şirketin belirli özelliklerine sahip oluşumlardır.
C# Inheritance (Miras Alma / Kalıtım) kavramı da tamamen bu örnek ile ilişkilidir, sınıflar birbirinden türeyebilir ve türeyen sınıf üst sınıfın özelliklerine sahip olur. Programlama açısından düşünürsek örneğin bir okul içi yazılım hazırladığımızı düşünelim. Veliler,öğrenciler,öğretmenler,idareciler gibi Class'lar oluşturduğumuzu varsayalım. Bu 4 class'ta da ortak kullanılacak kavramları örneğin; Tc kimlik no, Yaş, iletişim bilgileri vb. durumları Person isimli oluşturduğumuz bir class'tan kalıtabiliriz. Bu hem karışıklığı önler hem de zaman tasarrufu sağlar. 

<h3>C# Polymorphism (Çok Biçimlilik)</h3>
Alt Sınıf ve Üst Sınıfın özelliklerinden farklı şekilde davranışlar göstermesine Polymorphism denir. Örneğin; bir nesnenin diğer bir nesneyle ortak özellikleri olmasına rağmen farklı özelliklerininde tanımlanabilmesine denir. Bu durumda üst  sınıflardan türeyen alt sınıflar her zaman aynı özellikleri göstermek durumunda değildir mantığı ile düşünebiliriz. 

<h2>OOP Kullanan Yazılım Dilleri</h2>

Phyton

C++

Objective-C

Delphi

Smalltalk

Java

Swift

C#

Perl

Ruby

PHP

OOP yukarıdaki tüm ögelere sahiptir ancak ADA, JavaScript, Visual Basic gibi dillerden yoksundur.

