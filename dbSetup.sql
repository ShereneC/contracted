CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE contractors(  
    id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
    create_time DATETIME COMMENT 'create time',
    update_time DATETIME COMMENT 'update time',
    name varchar(255) NOT NULL comment 'User Name'
) default charset utf8 comment '';

CREATE TABLE companys(  
    id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
    create_time DATETIME COMMENT 'create time',
    update_time DATETIME COMMENT 'update time',
    name varchar(255) NOT NULL comment 'User Name'
) default charset utf8 comment '';

CREATE TABLE jobs (
  id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
  contractorId int NOT NULL comment 'Contractor Id References Contractor',
  companyId int NOT NULL comment 'Company Id References Company',
  FOREIGN KEY (contractorId) REFERENCES contractors(id) ON DELETE CASCADE,
  FOREIGN KEY (companyId) REFERENCES companys(id) ON DELETE CASCADE
) default charset utf8 comment '';
