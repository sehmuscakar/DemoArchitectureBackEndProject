Bu proje, bir Web API tabanlı kimlik doğrulama ve kullanıcı yönetimi sistemini simüle eder ve çoklu katmanlı bir mimariye sahip. Temelde, kullanıcılar ve rollerle ilgili işlemleri yönetmeye yönelik işlevsellik sunmaktadır. Proje, FluentValidation, Autofac Dependency Injection, ve Entity Framework Core kullanarak yapılandırılmıştır. İşte projenin detaylı özeti:

🎯 Proje Özeti
📂 Katmanlar ve Yapılar
1. Business Layer (İş Katmanı)
Abstract:

IAuthService.cs: Kimlik doğrulama işlemleri için kullanılacak servis arayüzü.

IOperationClaimService.cs: İşlem talepleri (roller) için servis arayüzü.

IUserOperationClaimService.cs: Kullanıcıların sahip olduğu rollerle ilgili işlemleri yönetmek için servis arayüzü.

IUserService.cs: Kullanıcı yönetimi ile ilgili servis arayüzü.

Concrete:

AuthManager.cs: Kimlik doğrulama işlemleri için iş mantığını içeren sınıf.

OperationClaimManager.cs: Rollerle ilgili işlemleri yöneten sınıf.

UserManager.cs: Kullanıcılarla ilgili işlemleri yöneten sınıf.

UserOperationClaimManager.cs: Kullanıcıların rollerini yönetmeye yönelik sınıf.

DependencyResolvers/Autofac:

AutofacBusinessModule.cs: Autofac dependency injection (DI) modülünü yapılandırarak, bağımlılıkların yönetilmesini sağlar.

ValidationRules/FluentValidation:

UserValidator.cs: FluentValidation kullanılarak kullanıcı doğrulama kuralları tanımlanır.

2. Core Layer (Çekirdek Katman)
CrossCuttingConcerns/Validation:

ValidationTool.cs: FluentValidation ile doğrulama işlemlerini merkezi bir noktada yapmak için kullanılan yardımcı sınıf.

3. DataAccess Layer (Veri Erişim Katmanı)
EntityFramework:

EfEntityRepositoryBase.cs: Entity Framework ile genel veri erişim işlemleri gerçekleştirilir.

IEntityRepository.cs: Varlıklar (Entity) için genel veri erişim arayüzü.

Concrete/EntityFramework:

Context/SimpleContextDb.cs: Veritabanı bağlamı (DbContext). Burada veritabanı bağlantısı ve işlemleri gerçekleştirilir.

EfOperationClaimDal.cs: İşlem talepleri (roller) veritabanı işlemleri.

EfUserDal.cs: Kullanıcı verileriyle ilgili veritabanı işlemleri.

EfUserOperationClaimDal.cs: Kullanıcı ve rollerin ilişkisiyle ilgili veritabanı işlemleri.

4. Entities Layer (Varlıklar Katmanı)
Concrete:

OperationClaim.cs: Kullanıcıların sahip olabileceği rollerin tanımlandığı varlık.

User.cs: Kullanıcı verilerinin yer aldığı varlık.

UserOperationClaim.cs: Kullanıcı ile rol ilişkilerini belirleyen varlık.

5. WebApi Layer (Web API Katmanı)
Controllers:

AuthController.cs: Kimlik doğrulama işlemleri (giriş, token oluşturma vb.) için API denetleyicisi.

OperationClaimsController.cs: Rollerle ilgili API denetleyicisi.

UserOperationClaimsController.cs: Kullanıcıların rollerini yönetmek için API denetleyicisi.

UsersController.cs: Kullanıcı yönetimi için API denetleyicisi.

WeatherForecastController.cs: Hava durumu gibi örnek bir API denetleyicisi (muhtemelen demo amaçlı).

Program.cs: Uygulamanın başlatıldığı ve yapılandırıldığı dosya.

WeatherForecast.cs: Hava durumu verisiyle ilgili model (muhtemelen demo).

6. WebApi.csproj: API projesinin yapılandırma dosyası.
⚙️ Özellikler ve İşlevler:
Kimlik Doğrulama: Kullanıcıların sisteme giriş yapabilmesi ve token alabilmesi sağlanır.

Kullanıcı Yönetimi: Kullanıcıların oluşturulması, güncellenmesi ve silinmesi işlemleri yapılabilir.

Rol Yönetimi: Kullanıcıların sahip olduğu rollerle ilgili işlemler yapılabilir.

API Endpoints: Kullanıcı, rol ve kimlik doğrulama işlemleri için API uç noktaları mevcuttur.

FluentValidation: Kullanıcı doğrulama işlemleri, FluentValidation kütüphanesi ile yapılır.

Dependency Injection: Autofac kullanılarak bağımlılıkların yönetimi sağlanır.

🛠️ Teknolojiler ve Yapılar:
ASP.NET Core Web API: Web API oluşturmak için kullanılan platform.

Entity Framework Core: Veritabanı işlemleri için kullanılan ORM.

FluentValidation: Veri doğrulama için kullanılan kütüphane.

Autofac: Bağımlılıkların enjekte edilmesi için kullanılan DI (Dependency Injection) framework.

JWT (JSON Web Token): Kimlik doğrulama işlemlerinde kullanılan token bazlı sistem.
