CREATE TABLE IF NOT exists public."Users" (
	"Id" serial4 NOT NULL,
    "Name" varchar(50) NULL,
    "SurName" varchar(50) NOT NULL,
    "Phone" varchar(50) NULL,
    "Email" varchar(50) NULL,
    "CreateDate" varchar(50) NULL
);

CREATE TABLE IF NOT exists public."Tasks"(
	"Id" serial4 NOT NULL,
	"Subject" varchar(255) NULL,
	"Description" text NULL,
	"Contractorid" int4 NULL,
	"Initiatorid" int4 NULL,
	"Createdate" varchar(50) NULL,
	"Deadlinedate" varchar(50) NULL
);