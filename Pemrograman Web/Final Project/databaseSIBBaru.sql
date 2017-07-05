/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     12/06/2017 20.20.55                          */
/*==============================================================*/


drop table if exists TB_APPLY_BEASISWA;

drop table if exists TB_BEASISWA;

drop table if exists TB_DETAIL_BEASISWA;

drop table if exists TB_DETAIL_PENDONOR;

drop table if exists TB_DETAIL_USER;

drop table if exists TB_DOKUMEN;

drop table if exists TB_DOKUMEN_PROSES;

drop table if exists TB_PENDONOR;

drop table if exists TB_REQUEST;

drop table if exists TB_USER;

/*==============================================================*/
/* Table: TB_APPLY_BEASISWA                                     */
/*==============================================================*/
create table TB_APPLY_BEASISWA
(
   ID_USER              int not null,
   ID_BEASISWA          int not null,
   TANGGAL_APPLY        date,
   STATUS_PENERIMAAN    varchar(30),
   STATUS_DOKUMEN       varchar(30),
   primary key (ID_USER, ID_BEASISWA)
);

/*==============================================================*/
/* Table: TB_BEASISWA                                           */
/*==============================================================*/
create table TB_BEASISWA
(
   ID_BEASISWA          int not null auto_increment,
   ID_DETAIL_BEASISWA   int not null,
   ID_PENDONOR          int not null,
   NAMA_BEASISWA        varchar(100),
   TANGGAL_BEASISWA_DIBUKA date,
   DEADLINE_BEASISWA    date,
   STATUS_BEASISWA      varchar(30),
   PENDAFTAR_BEASISWA   int,
   primary key (ID_BEASISWA)
)
auto_increment = 0;

/*==============================================================*/
/* Table: TB_DETAIL_BEASISWA                                    */
/*==============================================================*/
create table TB_DETAIL_BEASISWA
(
   ID_DETAIL_BEASISWA   int not null auto_increment,
   PERSYARATAN_DOKUMEN  varchar(100),
   CONTACT_PERSON_EMAIL varchar(80),
   CONTACT_PERSON_TELEPON varchar(15),
   ASAL_BEASISWA        varchar(80),
   DESKRIPSI_BEASISWA   text,
   JENIS_BEASISWA       varchar(50),
   TARGET_JURUSAN       varchar(50),
   TARGET_PRODI         varchar(6),
   TARGET_SEMESTER      varchar(1),
   PATH_FOTO_BEASISWA   varchar(255),
   PATH_FOTO_FEATURED   varchar(255),
   primary key (ID_DETAIL_BEASISWA)
)
auto_increment = 0;

/*==============================================================*/
/* Table: TB_DETAIL_PENDONOR                                    */
/*==============================================================*/
create table TB_DETAIL_PENDONOR
(
   ID_DETAIL_PENDONOR   int not null auto_increment,
   NAMA_PENDONOR        varchar(100),
   NOMOR_TELEPON_PENDONOR varchar(15),
   ALAMAT_PENDONOR      varchar(100),
   PATH_DOKUMEN_LEGALISIR varchar(255),
   STATUS_AKUN_PENDONOR varchar(50),
   NAMA_PJ_BEASISWA     varchar(100),
   primary key (ID_DETAIL_PENDONOR)
)
auto_increment = 0;

/*==============================================================*/
/* Table: TB_DETAIL_USER                                        */
/*==============================================================*/
create table TB_DETAIL_USER
(
   ID_DETAIL_USER       int not null auto_increment,
   NAMA_LENGKAP         varchar(80),
   USIA                 int,
   JENIS_KELAMIN        varchar(80),
   PROVINSI             varchar(50),
   KOTA                 varchar(50),
   ALAMAT               varchar(100),
   KELAS                varchar(1),
   PRODI                varchar(6),
   JURUSAN              varchar(50),
   PARAREL              varchar(1),
   SEMESTER             varchar(1),
   TANGGAL_LAHIR        date,
   TEMPAT_LAHIR         varchar(50),
   TANGGAL_MASUK        date,
   PATH_FOTO            varchar(255),
   NRP                  varchar(10),
   NIP                  varchar(20),
   primary key (ID_DETAIL_USER)
)
auto_increment = 0;

/*==============================================================*/
/* Table: TB_DOKUMEN                                            */
/*==============================================================*/
create table TB_DOKUMEN
(
   ID_DOKUMEN           int not null auto_increment,
   ID_USER              int,
   NAMA_DOKUMEN         varchar(100),
   PATH_DOKUMEN         varchar(255),
   JENIS_DOKUMEN        varchar(50),
   primary key (ID_DOKUMEN)
)
auto_increment = 0;

/*==============================================================*/
/* Table: TB_DOKUMEN_PROSES                                     */
/*==============================================================*/
create table TB_DOKUMEN_PROSES
(
   ID_DOKUMEN_PROSES    int not null auto_increment,
   NAMA_DOKUMEN_PROSES  varchar(100),
   JENIS_DOKUMEN_PROSES varchar(50),
   primary key (ID_DOKUMEN_PROSES)
)
auto_increment = 0;

/*==============================================================*/
/* Table: TB_PENDONOR                                           */
/*==============================================================*/
create table TB_PENDONOR
(
   ID_PENDONOR          int not null auto_increment,
   ID_DETAIL_PENDONOR   int not null,
   USER_PENDONOR        varchar(50),
   PASSWORD_PENDONOR    varchar(30),
   EMAIL_PENDONOR       varchar(50),
   SALT_PENDONOR        varchar(5),
   TANGGAL_PEMBUATAN_PENDONOR datetime,
   TERAKHIR_LOGIN_PENDONOR datetime,
   primary key (ID_PENDONOR)
)
auto_increment = 0;

/*==============================================================*/
/* Table: TB_REQUEST                                            */
/*==============================================================*/
create table TB_REQUEST
(
   ID_USER              int not null,
   ID_DOKUMEN_PROSES    int not null,
   TANGGAL_REQUEST_DOKUMEN datetime,
   TANGGAL_REQUEST_DIPENUHI datetime,
   STATUS_REQUEST_DOKUMEN varchar(30),
   CATATAN_TAMBAHAN_REQUEST text,
   primary key (ID_USER, ID_DOKUMEN_PROSES)
);

/*==============================================================*/
/* Table: TB_USER                                               */
/*==============================================================*/
create table TB_USER
(
   ID_USER              int not null auto_increment,
   ID_DETAIL_USER       int not null,
   EMAIL                varchar(50),
   PASSWORD             varchar(30),
   SALT                 varchar(5),
   TANGGAL_PEMBUATAN    datetime,
   TERAKHIR_LOGIN       datetime,
   primary key (ID_USER)
)
auto_increment = 0;

alter table TB_APPLY_BEASISWA add constraint FK_RELATIONSHIP_8 foreign key (ID_USER)
      references TB_USER (ID_USER) on delete restrict on update restrict;

alter table TB_APPLY_BEASISWA add constraint FK_RELATIONSHIP_9 foreign key (ID_BEASISWA)
      references TB_BEASISWA (ID_BEASISWA) on delete restrict on update restrict;

alter table TB_BEASISWA add constraint FK_MEMBUAT_BASIS_BEASISWA foreign key (ID_PENDONOR)
      references TB_PENDONOR (ID_PENDONOR) on delete restrict on update restrict;

alter table TB_BEASISWA add constraint FK_MEMILIKI_DETAIL_BEASISWA foreign key (ID_DETAIL_BEASISWA)
      references TB_DETAIL_BEASISWA (ID_DETAIL_BEASISWA) on delete restrict on update restrict;

alter table TB_DOKUMEN add constraint FK_MEMILIKI foreign key (ID_USER)
      references TB_USER (ID_USER) on delete restrict on update restrict;

alter table TB_PENDONOR add constraint FK_MEMILIKI_DETAIL_PENDONOR foreign key (ID_DETAIL_PENDONOR)
      references TB_DETAIL_PENDONOR (ID_DETAIL_PENDONOR) on delete restrict on update restrict;

alter table TB_REQUEST add constraint FK_RELATIONSHIP_10 foreign key (ID_USER)
      references TB_USER (ID_USER) on delete restrict on update restrict;

alter table TB_REQUEST add constraint FK_RELATIONSHIP_11 foreign key (ID_DOKUMEN_PROSES)
      references TB_DOKUMEN_PROSES (ID_DOKUMEN_PROSES) on delete restrict on update restrict;

alter table TB_USER add constraint FK_MEMILIKI_DETAIL foreign key (ID_DETAIL_USER)
      references TB_DETAIL_USER (ID_DETAIL_USER) on delete restrict on update restrict;

