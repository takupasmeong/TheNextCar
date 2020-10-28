# The Next Car
implementasi MVC membuat dashboard electric car.

## Functionalities
- User dapat menekan tombol STARTED dan label akan muncul peringatan jika pintu belum tertutup dan belum terkunci serta mesin belum menyala.
- User dapat menekan tombol CLOSED untuk menutup pintu.
- User dapat menekan tombol LOCKED untuk mengunci pintu.
- User dapat menekan tombol POWER untuk menyalakan mesin.

## How Does It Works
Terdapat class `DoorController.cs` yang berfungsi untuk mengontrol label dan button sehingga value dan message akan berubah ketika tombol ditekan, menggunakan interface `OnDoorChanged` yang memiliki 2 function controller.
```csharp
interface OnDoorChanged
    {
        void doorSecurityChanged(string vale, string message);
        void doorStatusChanged(string vale, string message);
    }
```
interface ini berfungsi untuk mengirim inputan dari class `MainWindow` yang kemudian akan diproses di class `DoorController.cs` untuk memberikan logic dan output bilamana pintu terbuka dan tertutup, terkunci dan terbuka.<br/><br/>Pada class `Door.cs` mengatur logic false true untuk button buka pintu dan button kunci pintu, dan mengembalikan valuenya menggunakan function `isLocked` dan `isCloced`.
```csharp
public bool isLocked()
{
    return this.locked;
}

public bool isClosed()
{
    return this.closed;
}
```
class `Door.cs` dipanggil pada class `DoorController.cs` sehingga terhubung dengan output yang dihasilkan melalui interface `OnDoorChanged`.
```csharp
private Door door;
private OnDoorChanged OnDoorChanged;

public DoorController(OnDoorChanged onDoorChanged)
{
    this.door = new Door();
    this.OnDoorChanged = onDoorChanged;
}
```
