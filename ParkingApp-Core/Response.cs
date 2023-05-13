using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp_Core
{

    public class Response
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; }
        public object Result { get; set; }
        public int Count { get; set; } = 0;
        public int Size { get; set; } = 0;
        public int MaxSize { get; set; } = 0;
        public int FilteredSize { get; set; } = 0;
        public int Row { get; set; } = 0;
        public int MaxRow { get; set; } = 0;
        public bool IsEmpty { get; set; } = false;
        public Error Exception { get; set; } = new Error();

        public void ResponseFiller(int EntityListCount, int MaxSize, int FilteredCount, int Size, int Row, dynamic data, string what = null)
        {
            Success = EntityListCount > 0;
            Message = !string.IsNullOrEmpty(what) ? EntityListCount > 0 ? EntityListCount + " " + what + " bulundu" : what + " bulunamadı"
                : EntityListCount > 0 ? EntityListCount + " kayıt bulundu" : "Kayıt bulunamadı";
            Count = EntityListCount;
            Result = data;
            this.Size = Size;
            this.MaxSize = MaxSize;
            FilteredSize = FilteredCount;
            this.Row = Row;
            MaxRow = Size == 0 ? 0 : (int)Math.Ceiling(Decimal.Divide(FilteredCount, Size));
            IsEmpty = EntityListCount == 0;
        }

        public void getException(Exception ex, bool IsMessageOverwrite = false)
        {
            if (IsMessageOverwrite)
                Message = "Sistem Hatası";

            Success = false;
            Result = null;
            Row = 0;
            MaxRow = 0;
            Count = 0;
            Size = 0;
            MaxSize = 0;
            Exception.ErrorCode = ex.HResult;
            Exception.Message = string.IsNullOrEmpty(ex.Message) ? Message : ex.Message;
            Exception.InnerException = ex.InnerException == null ? "" : ex.InnerException.ToString();
            //Exception.StatusCode = ex.HResult == -2146233088 ? (int)HttpStatusCode.Unauthorized : (int)HttpStatusCode.InternalServerError;
        }

        public void FoundStatus(int Count)
        {
            this.Message = Count == 0 ? "Kayıt bulunamadı" : Count + " kayıt bulundu";
        }

        public void FoundUser(bool status)
        {
            this.Message = status ? "Giriş Başarılı" : "Giriş Başarısız";
        }

        public void CreateStatus(bool status)
        {
            this.Message = status ? "Kayıt başarılı" : "Kayıt başarısız";
        }

        public void UpdateStatus(bool status)
        {
            this.Message = status ? "Kayıt güncellendi" : "Kayıt güncellenemedi";
        }

        public void EmptyField()
        {
            this.Message = "Lütfen tüm alanları doldurunuz.";
        }

        public void DeleteStatus(bool status)
        {
            this.Message = status ? "Kayıt silindi" : "Kayıt silinemedi";
        }

        public void AlreadyExist()
        {
            this.Message = "Kullanıcı kaydı mevcut";
        }

        public void AlreadyExistLicense()
        {
            this.Message = "Lisans kaydı mevcut";
        }

        public void SubUserCount()
        {
            this.Message = "Kullanıcı oluşturma hakkınız bitmiştir.";
        }

        public void CantDelete()
        {
            this.Message = "Kayıt silinemez";
        }
    }


    public partial class Error
    {
        public virtual int ErrorCode { get; set; } = -1;
        public virtual string Message { get; set; }
        public virtual string InnerException { get; set; }
        public virtual int StatusCode { get; set; }
    }


}
