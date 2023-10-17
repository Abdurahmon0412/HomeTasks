//- fayllar umumiy hajmi ( size ) va eng katta fayl qaysi ekanligini qaytaradigan service
//va methodlar yozing ( nomlarini o'zingiz o'ylab ko'ring ) 
//- tepada aytilgan ma'lumotlarni ekranga chiqaring

using WorkingWithFiles.FilesManagementService;

var folderPath = @"D:\Projects\HighLavelHomeTask\HomeTasks\WorkingWithFiles\bin\Debug\net7.0\Folders";
//var targetFileName = @"D:\Projects\HighLavelHomeTask\HomeTasks\WorkingWithFiles\bin\Debug\net7.0";


var service = new FilesManagementService();
service.FilesAndFoldersCount(folderPath);
service.AllFilesLenght(folderPath);