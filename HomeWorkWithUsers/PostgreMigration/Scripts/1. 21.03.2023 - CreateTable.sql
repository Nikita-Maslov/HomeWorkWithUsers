CREATE TABLE IF NOT exists public."Users" (
	"Id" serial4 NOT NULL,
    "Name" varchar(50) NULL,
    "SurName" varchar(50) NOT NULL,
    "Phone" varchar(50) NULL,
    "Email" varchar(50) NULL,
    "CreateDate" timestamptz  NULL
);