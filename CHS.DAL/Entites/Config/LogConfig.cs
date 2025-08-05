

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CHS.DAL.Entites.Config
{
    public class LogConfig : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Message).HasColumnType("nvarchar(max)");
            builder.Property(l => l.MessageTemplate).HasColumnType("nvarchar(max)");
            builder.Property(l => l.Level).HasMaxLength(128);
            builder.Property(l => l.TimeStamp).HasColumnType("datetimeoffset");
            builder.Property(l => l.Exception).HasColumnType("nvarchar(max)");
            builder.Property(l => l.Properties).HasColumnType("nvarchar(max)");
            builder.Property(l => l.LogEvent).HasColumnType("nvarchar(max)");

            // Custom columns
            builder.Property(l => l.RequestPath).HasMaxLength(512);
            builder.Property(l => l.RequestBody).HasColumnType("nvarchar(max)");
            builder.Property(l => l.ResponseBody).HasColumnType("nvarchar(max)");
            builder.Property(l => l.UserId).HasMaxLength(128);
            builder.Property(l => l.ClientIp).HasMaxLength(64);
            builder.Property(l => l.ElapsedMilliseconds).HasColumnType("int");
        }
    }
}