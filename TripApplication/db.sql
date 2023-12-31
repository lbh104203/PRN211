USE [TripManagement]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 12/4/2023 12:49:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NULL,
	[role] [nvarchar](50) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 12/4/2023 12:49:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[booking_id] [int] IDENTITY(1,1) NOT NULL,
	[trip_id] [int] NULL,
	[customer] [nvarchar](50) NULL,
	[phone] [nvarchar](50) NULL,
	[seatsStatus] [nvarchar](max) NULL,
	[amount] [money] NULL,
	[created_by] [nvarchar](50) NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[booking_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Limousine]    Script Date: 12/4/2023 12:49:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Limousine](
	[limousine_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[plate] [nvarchar](50) NULL,
	[numberRows] [int] NULL,
	[numberCols] [int] NULL,
	[type] [int] NULL,
 CONSTRAINT [PK_Limousine] PRIMARY KEY CLUSTERED 
(
	[limousine_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Limousine_Type]    Script Date: 12/4/2023 12:49:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Limousine_Type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [nvarchar](50) NULL,
	[unit_price] [money] NULL,
 CONSTRAINT [PK_Limousine_Type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 12/4/2023 12:49:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[location_code] [nvarchar](10) NOT NULL,
	[location_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[location_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Route]    Script Date: 12/4/2023 12:49:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Route](
	[route_id] [int] IDENTITY(1,1) NOT NULL,
	[route_name] [nvarchar](max) NULL,
	[route_from] [nvarchar](10) NULL,
	[route_to] [nvarchar](10) NULL,
	[distance] [float] NULL,
 CONSTRAINT [PK_Route] PRIMARY KEY CLUSTERED 
(
	[route_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trip]    Script Date: 12/4/2023 12:49:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trip](
	[trip_id] [int] IDENTITY(1,1) NOT NULL,
	[route_id] [int] NULL,
	[date] [date] NULL,
	[slot] [int] NULL,
	[price] [money] NULL,
	[limousine_id] [int] NULL,
	[status] [int] NULL,
	[create_by] [nvarchar](50) NULL,
 CONSTRAINT [PK_Trip] PRIMARY KEY CLUSTERED 
(
	[trip_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([username], [password], [role]) VALUES (N'admin', N'admin', N'admin')
INSERT [dbo].[Account] ([username], [password], [role]) VALUES (N'adminAnh', N'123', N'admin')
INSERT [dbo].[Account] ([username], [password], [role]) VALUES (N'staff', N'123', N'staff')
GO
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([booking_id], [trip_id], [customer], [phone], [seatsStatus], [amount], [created_by]) VALUES (3, 2, N'Hang Nga', N'0888888888', N'000000000111000000000000', 900.0000, N'staff')
INSERT [dbo].[Booking] ([booking_id], [trip_id], [customer], [phone], [seatsStatus], [amount], [created_by]) VALUES (5, 1, N'A', N'90123456789', N'000000000000000111000000', 900.0000, N'staff')
INSERT [dbo].[Booking] ([booking_id], [trip_id], [customer], [phone], [seatsStatus], [amount], [created_by]) VALUES (9, 2, N'HANH', N'0123456789', N'000111111000111111111000', 4500.0000, N'staff')
INSERT [dbo].[Booking] ([booking_id], [trip_id], [customer], [phone], [seatsStatus], [amount], [created_by]) VALUES (10, 2, N'a', N'123', N'111000000000000000000000', 900.0000, N'staff')
INSERT [dbo].[Booking] ([booking_id], [trip_id], [customer], [phone], [seatsStatus], [amount], [created_by]) VALUES (24, 2, N'', N'0123456789', N'000000000000000000000111', 900.0000, N'staff')
INSERT [dbo].[Booking] ([booking_id], [trip_id], [customer], [phone], [seatsStatus], [amount], [created_by]) VALUES (25, 4, N'Ha', N'0123456789', N'11111100000000000000', 1800.0000, N'staff')
INSERT [dbo].[Booking] ([booking_id], [trip_id], [customer], [phone], [seatsStatus], [amount], [created_by]) VALUES (27, 4, N'', N'0123456789', N'00000011111111111111', 4200.0000, N'staff')
SET IDENTITY_INSERT [dbo].[Booking] OFF
GO
SET IDENTITY_INSERT [dbo].[Limousine] ON 

INSERT [dbo].[Limousine] ([limousine_id], [name], [plate], [numberRows], [numberCols], [type]) VALUES (1, N'GT01NA', N'11N-11111', 8, 3, 1)
INSERT [dbo].[Limousine] ([limousine_id], [name], [plate], [numberRows], [numberCols], [type]) VALUES (2, N'GT03V', N'22N-22222', 10, 2, 1)
INSERT [dbo].[Limousine] ([limousine_id], [name], [plate], [numberRows], [numberCols], [type]) VALUES (3, N'Lac Hong Sunrise', N'33V-33333', 10, 2, 2)
INSERT [dbo].[Limousine] ([limousine_id], [name], [plate], [numberRows], [numberCols], [type]) VALUES (4, N'HNGANH', N'12V-34567', 5, 2, 2)
INSERT [dbo].[Limousine] ([limousine_id], [name], [plate], [numberRows], [numberCols], [type]) VALUES (5, N'Goodbye World', N'12N-1212', 5, 2, 1)
INSERT [dbo].[Limousine] ([limousine_id], [name], [plate], [numberRows], [numberCols], [type]) VALUES (6, N'Hello', N'10V-12190', 5, 2, 2)
SET IDENTITY_INSERT [dbo].[Limousine] OFF
GO
SET IDENTITY_INSERT [dbo].[Limousine_Type] ON 

INSERT [dbo].[Limousine_Type] ([id], [type], [unit_price]) VALUES (1, N'NORMAL', 1.0000)
INSERT [dbo].[Limousine_Type] ([id], [type], [unit_price]) VALUES (2, N'VIP', 2.0000)
SET IDENTITY_INSERT [dbo].[Limousine_Type] OFF
GO
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'AG', N'An Giang')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'BD', N'Bình Định')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'BDG', N'Bình Dương')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'BG', N'Bắc Giang')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'BGi', N'Bắc Giang')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'BK', N'Bắc Kạn')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'BL', N'Bạc Liêu')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'BNi', N'Bắc Ninh')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'BP', N'Bình Phước')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'BRVT', N'Bà Rịa - Vũng Tàu')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'BT', N'Bến Tre')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'BTh', N'Bình Thuận')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'CB', N'Cao Bằng')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'CM', N'Cà Mau')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'CT', N'Cần Thơ')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'ÐL', N'Đắk Lắk')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'DN', N'Đà Nẵng')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'DNa', N'Đồng Nai')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'DNo', N'Đắk Nông')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'ÐT', N'Đồng Tháp')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'GL', N'Gia Lai')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'HCM', N'Hồ Chí Minh')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'HD', N'Hải Dương')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'HG', N'Hà Giang')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'HGi', N'Hậu Giang')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'HN', N'Hà Nội')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'HNa', N'Hà Nam')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'HT', N'Hà Tĩnh')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'HY', N'Hưng Yên')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'KG', N'Kiên Giang')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'KH', N'Khánh Hòa')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'KT', N'Kon Tum')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'LA', N'Long An')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'LC', N'Lai Châu')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'LCA', N'Lào Cai')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'LD', N'Lâm Đồng')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'LS', N'Lạng Sơn')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'NA', N'Nghệ An')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'NB', N'Ninh Bình')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'ND', N'Nam Định')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'NT', N'Ninh Thuận')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'PT', N'Phú Thọ')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'PY', N'Phú Yên')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'QB', N'Quảng Bình')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'QG', N'Quảng Ngãi')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'QN', N'Quảng Ninh')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'QNa', N'Quảng Nam')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'QT', N'Quảng Trị')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'SL', N'Sơn La')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'ST', N'Sóc Trăng')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'TB', N'Thái Bình')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'TG', N'Tiền Giang')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'TH', N'Thanh Hóa')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'TN', N'Thái Nguyên')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'TNh', N'Tây Ninh')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'TQ', N'Tuyên Quang')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'TT', N'Thừa Thiên Huế')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'TV', N'Trà Vinh')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'VL', N'Vĩnh Long')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'VP', N'Vĩnh Phúc')
INSERT [dbo].[Location] ([location_code], [location_name]) VALUES (N'YB', N'Yên Bái')
GO
SET IDENTITY_INSERT [dbo].[Route] ON 

INSERT [dbo].[Route] ([route_id], [route_name], [route_from], [route_to], [distance]) VALUES (1, N'Hà Nội - Nghệ An', N'HN', N'NA', 300)
INSERT [dbo].[Route] ([route_id], [route_name], [route_from], [route_to], [distance]) VALUES (2, N'Nghệ An - Hà Nội', N'NA', N'HN', 300)
INSERT [dbo].[Route] ([route_id], [route_name], [route_from], [route_to], [distance]) VALUES (3, N'Bắc Giang - Hà Nội', N'BG', N'HN', 100)
INSERT [dbo].[Route] ([route_id], [route_name], [route_from], [route_to], [distance]) VALUES (4, N'Bắc Kạn - Hà Nội', N'BK', N'HN', 200)
INSERT [dbo].[Route] ([route_id], [route_name], [route_from], [route_to], [distance]) VALUES (5, N'Hà Nội - Thanh Hóa', N'HN', N'TH', 100)
INSERT [dbo].[Route] ([route_id], [route_name], [route_from], [route_to], [distance]) VALUES (15, N'Hà Nội - Hà Giang', N'HN', N'HG', 150)
INSERT [dbo].[Route] ([route_id], [route_name], [route_from], [route_to], [distance]) VALUES (16, N'Hà Nội - Ninh Bình', N'HN', N'NB', 120)
INSERT [dbo].[Route] ([route_id], [route_name], [route_from], [route_to], [distance]) VALUES (19, N'Hà Nội - Bắc Ninh', N'HN', N'BNi', 120)
SET IDENTITY_INSERT [dbo].[Route] OFF
GO
SET IDENTITY_INSERT [dbo].[Trip] ON 

INSERT [dbo].[Trip] ([trip_id], [route_id], [date], [slot], [price], [limousine_id], [status], [create_by]) VALUES (1, 1, CAST(N'2023-11-07' AS Date), 1, 300.0000, 1, 3, N'admin')
INSERT [dbo].[Trip] ([trip_id], [route_id], [date], [slot], [price], [limousine_id], [status], [create_by]) VALUES (2, 1, CAST(N'2023-11-12' AS Date), 1, 300.0000, 1, 3, N'admin')
INSERT [dbo].[Trip] ([trip_id], [route_id], [date], [slot], [price], [limousine_id], [status], [create_by]) VALUES (4, 1, CAST(N'2023-11-12' AS Date), 1, 300.0000, 2, 2, N'admin')
INSERT [dbo].[Trip] ([trip_id], [route_id], [date], [slot], [price], [limousine_id], [status], [create_by]) VALUES (5, 1, CAST(N'2023-11-13' AS Date), 2, 300.0000, 2, 1, N'admin')
INSERT [dbo].[Trip] ([trip_id], [route_id], [date], [slot], [price], [limousine_id], [status], [create_by]) VALUES (9, 4, CAST(N'2023-11-24' AS Date), 1, 600.0000, 4, 1, N'admin')
INSERT [dbo].[Trip] ([trip_id], [route_id], [date], [slot], [price], [limousine_id], [status], [create_by]) VALUES (11, 4, CAST(N'2023-11-24' AS Date), 1, 200.0000, 1, 1, N'admin')
INSERT [dbo].[Trip] ([trip_id], [route_id], [date], [slot], [price], [limousine_id], [status], [create_by]) VALUES (12, 1, CAST(N'2023-11-13' AS Date), 1, 600.0000, 3, 1, N'admin')
SET IDENTITY_INSERT [dbo].[Trip] OFF
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Account] FOREIGN KEY([created_by])
REFERENCES [dbo].[Account] ([username])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Account]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Trip] FOREIGN KEY([trip_id])
REFERENCES [dbo].[Trip] ([trip_id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Trip]
GO
ALTER TABLE [dbo].[Limousine]  WITH CHECK ADD  CONSTRAINT [FK_Limousine_Limousine_Type] FOREIGN KEY([type])
REFERENCES [dbo].[Limousine_Type] ([id])
GO
ALTER TABLE [dbo].[Limousine] CHECK CONSTRAINT [FK_Limousine_Limousine_Type]
GO
ALTER TABLE [dbo].[Route]  WITH CHECK ADD  CONSTRAINT [FK_Route_Location] FOREIGN KEY([route_from])
REFERENCES [dbo].[Location] ([location_code])
GO
ALTER TABLE [dbo].[Route] CHECK CONSTRAINT [FK_Route_Location]
GO
ALTER TABLE [dbo].[Route]  WITH CHECK ADD  CONSTRAINT [FK_Route_Location1] FOREIGN KEY([route_to])
REFERENCES [dbo].[Location] ([location_code])
GO
ALTER TABLE [dbo].[Route] CHECK CONSTRAINT [FK_Route_Location1]
GO
ALTER TABLE [dbo].[Trip]  WITH CHECK ADD  CONSTRAINT [FK_Trip_Account] FOREIGN KEY([create_by])
REFERENCES [dbo].[Account] ([username])
GO
ALTER TABLE [dbo].[Trip] CHECK CONSTRAINT [FK_Trip_Account]
GO
ALTER TABLE [dbo].[Trip]  WITH CHECK ADD  CONSTRAINT [FK_Trip_Limousine] FOREIGN KEY([limousine_id])
REFERENCES [dbo].[Limousine] ([limousine_id])
GO
ALTER TABLE [dbo].[Trip] CHECK CONSTRAINT [FK_Trip_Limousine]
GO
ALTER TABLE [dbo].[Trip]  WITH CHECK ADD  CONSTRAINT [FK_Trip_Route] FOREIGN KEY([route_id])
REFERENCES [dbo].[Route] ([route_id])
GO
ALTER TABLE [dbo].[Trip] CHECK CONSTRAINT [FK_Trip_Route]
GO
