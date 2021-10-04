-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema cafeteria_management
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema cafeteria_management
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `cafeteria_management` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci ;
USE `cafeteria_management` ;

-- -----------------------------------------------------
-- Table `cafeteria_management`.`account`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `cafeteria_management`.`account` (
  `UserName` VARCHAR(255) NOT NULL,
  `DisplayName` VARCHAR(255) NOT NULL DEFAULT 'Unknown',
  `PassWord` VARCHAR(1023) NOT NULL DEFAULT '0',
  `Type` INT NOT NULL DEFAULT '0',
  PRIMARY KEY (`UserName`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `cafeteria_management`.`tablefood`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `cafeteria_management`.`tablefood` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) NOT NULL DEFAULT 'Bàn chưa có tên',
  `status` VARCHAR(255) NOT NULL DEFAULT 'Trống',
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `cafeteria_management`.`bill`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `cafeteria_management`.`bill` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `DateCheckIn` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `DateCheckOut` DATETIME NULL DEFAULT NULL,
  `idTable` INT NOT NULL,
  `status` INT NOT NULL DEFAULT '0',
  `discount` INT NULL DEFAULT '0',
  `totalPrice` FLOAT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  INDEX `idTable` (`idTable` ASC) VISIBLE,
  CONSTRAINT `bill_ibfk_1`
    FOREIGN KEY (`idTable`)
    REFERENCES `cafeteria_management`.`tablefood` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `cafeteria_management`.`foodcategory`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `cafeteria_management`.`foodcategory` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) NOT NULL DEFAULT 'Chưa đặt tên',
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 10
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `cafeteria_management`.`food`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `cafeteria_management`.`food` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) NOT NULL DEFAULT 'Chưa đặt tên',
  `idCategory` INT NOT NULL,
  `price` FLOAT NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  INDEX `idCategory` (`idCategory` ASC) VISIBLE,
  CONSTRAINT `food_ibfk_1`
    FOREIGN KEY (`idCategory`)
    REFERENCES `cafeteria_management`.`foodcategory` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 16
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `cafeteria_management`.`billinfo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `cafeteria_management`.`billinfo` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `idBill` INT NOT NULL,
  `idFood` INT NULL DEFAULT NULL,
  `Count` INT NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  INDEX `idBill` (`idBill` ASC) VISIBLE,
  INDEX `billinfo_ibfk_2` (`idFood` ASC) VISIBLE,
  CONSTRAINT `billinfo_ibfk_1`
    FOREIGN KEY (`idBill`)
    REFERENCES `cafeteria_management`.`bill` (`id`),
  CONSTRAINT `billinfo_ibfk_2`
    FOREIGN KEY (`idFood`)
    REFERENCES `cafeteria_management`.`food` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;

USE `cafeteria_management` ;

-- -----------------------------------------------------
-- Placeholder table for view `cafeteria_management`.`viewbillinfo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `cafeteria_management`.`viewbillinfo` (`ID` INT, `Món ăn` INT, `Số lượng` INT, `Tên bàn` INT, `Trạng thái` INT);

-- -----------------------------------------------------
-- procedure spAccount_GetAll
-- -----------------------------------------------------

DELIMITER $$
USE `cafeteria_management`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spAccount_GetAll`()
BEGIN
	SELECT UserName 'Tên người dùng', DisplayName 'Tên hiển thị', Type 'Loại tài khoản'
    FROM Account;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure spAccount_GetByUserName
-- -----------------------------------------------------

DELIMITER $$
USE `cafeteria_management`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spAccount_GetByUserName`(IN userNameVal VARCHAR(100))
BEGIN
	SELECT UserName 'Tên người dùng', DisplayName 'Tên hiển thị', Type 'Loại tài khoản'
    FROM Account WHERE UserName = userNameVal;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure spAccount_Update
-- -----------------------------------------------------

DELIMITER $$
USE `cafeteria_management`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spAccount_Update`(IN userNameVal VARCHAR(255), IN displayNameVal VARCHAR(255), IN passwordVal VARCHAR(1023), IN newPasswordVal VARCHAR(1023))
BEGIN
	DECLARE isCorrectPass INT DEFAULT 0;
    
    SELECT COUNT(*) INTO isCorrectPass
    FROM Account
    WHERE UserName = userNameVal AND PassWord = passwordVal;
    
    IF isCorrectPass = 1 THEN
		IF newPasswordVal = NULL OR newPasswordVal = '' THEN
			UPDATE Account SET DisplayName = displayNameVal
            WHERE UserName = userNameVal;
		ELSE
			UPDATE Account
            SET DisplayName = displayNameVal, PassWord = newPasswordVal
            WHERE UserName = userNameVal;
		END IF;
    END IF;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure spBillInfo_Insert
-- -----------------------------------------------------

DELIMITER $$
USE `cafeteria_management`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spBillInfo_Insert`(IN idBillVal INT, IN idFoodVal INT, IN countVal INT)
BEGIN
	DECLARE isExistBillInfo INT DEFAULT 0;
    DECLARE foodCount INT DEFAULT 1;
    DECLARE newCountVal INT;
    
    SELECT SUM(id), SUM(Count)
    INTO isExistBillInfo, foodCount
    FROM BillInfo
    WHERE idBill = idBillVal AND idFood = idFoodVal;
    
    IF isExistBillInfo > 0 THEN
        SET newCountVal = foodCount + countVal;
        IF newCountVal > 0 THEN
			UPDATE BillInfo SET Count = newCountVal
            WHERE idBill = idBillVal AND idFood = idFoodVal;
		ELSE
			DELETE FROM BillInfo
            WHERE idBill = idBillVal AND idFood = idFoodVal;
		END IF;
	ELSE
		IF countVal > 0 THEN
			INSERT INTO BillInfo(idBill, idFood, Count)
            VALUES (idBillVal, idFoodVal, countVal);
		END IF;
	END IF;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure spBill_Insert
-- -----------------------------------------------------

DELIMITER $$
USE `cafeteria_management`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spBill_Insert`(IN idTableVal INT)
BEGIN
	INSERT INTO Bill(DateCheckIn, DateCheckOut, idTable, status, discount)
    VALUES (NOW(), NULL, idTableVal, 0, 0);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure spBills_GetByDateTime
-- -----------------------------------------------------

DELIMITER $$
USE `cafeteria_management`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spBills_GetByDateTime`(IN checkInVal DATETIME, IN checkOutVal DATETIME)
BEGIN
	SELECT
		tf.name 'Tên bàn',
        b.totalPrice 'Tổng tiền',
        b.DateCheckIn 'Ngày vào',
        b.DateCheckOut 'Ngày ra',
        b.discount 'Được giảm (%)'
    FROM Bill b
    INNER JOIN TableFood tf ON b.idTable = tf.id
    WHERE DateCheckIn >= checkInVal AND DateCheckOut <= checkOutVal AND b.status = 1;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure spFoodCategory_GetAll
-- -----------------------------------------------------

DELIMITER $$
USE `cafeteria_management`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFoodCategory_GetAll`()
BEGIN
	SELECT * FROM FoodCategory;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure spFoodCategory_Insert
-- -----------------------------------------------------

DELIMITER $$
USE `cafeteria_management`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFoodCategory_Insert`(IN nameVal VARCHAR(255))
BEGIN
	INSERT INTO FoodCategory(name)
    VALUES (nameVal);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure spFood_GetAll
-- -----------------------------------------------------

DELIMITER $$
USE `cafeteria_management`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFood_GetAll`()
BEGIN
	SELECT *
    FROM Food;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure spFood_GetById
-- -----------------------------------------------------

DELIMITER $$
USE `cafeteria_management`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFood_GetById`(IN idVal INT)
BEGIN
	SELECT * FROM Food WHERE id = idVal;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure spFood_Insert
-- -----------------------------------------------------

DELIMITER $$
USE `cafeteria_management`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFood_Insert`(IN nameVal VARCHAR(255), IN idCategoryVal INT, IN priceVal FLOAT)
BEGIN
	INSERT INTO Food(name, idCategory, price)
    VALUES (nameVal, idCategoryVal, priceVal);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure spFoods_GetByFoodCategory
-- -----------------------------------------------------

DELIMITER $$
USE `cafeteria_management`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFoods_GetByFoodCategory`(IN idVal INT)
BEGIN
	SELECT * FROM Food WHERE idCategory = idVal;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure spLogin_Authentication
-- -----------------------------------------------------

DELIMITER $$
USE `cafeteria_management`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spLogin_Authentication`(IN userNameVal VARCHAR(100), IN passWordVal VARCHAR(1000))
BEGIN
	SELECT * FROM Account
    WHERE UserName = userNameVal AND PassWord = passWordVal;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure spSwitchTable
-- -----------------------------------------------------

DELIMITER $$
USE `cafeteria_management`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spSwitchTable`(IN idFromTable INT, IN idToTable INT)
BEGIN
	DECLARE idFirstBill INT;
    DECLARE idSecondBill INT;
    
    SELECT id INTO idFirstBill FROM Bill WHERE idTable = idFromTable AND status = 0;
    SELECT id INTO idSecondBill FROM Bill WHERE idTable = idToTable AND status = 0;
    
    IF idFirstBill IS NULL THEN
		INSERT INTO Bill(DateCheckIn, DateCheckOut, idTable, status)
        VALUES (NOW(), NULL, idFromTable, 0);
        SELECT MAX(id) INTO idFirstBill FROM Bill WHERE idTable = idFromTable AND status = 0;
    END IF;
    
    IF idSecondBill IS NULL THEN
		INSERT INTO Bill(DateCheckIn, DateCheckOut, idTable, status)
        VALUES (NOW(), NULL, idToTable, 0);
        SELECT MAX(id) INTO idSecondBill FROM Bill WHERE idTable = idToTable AND status = 0;
    END IF;
    
    CREATE TEMPORARY TABLE IdBillInfoTable(SELECT id FROM BillInfo WHERE idBill = idSecondBill);
    
    UPDATE BillInfo SET idBill = idSecondBill WHERE idBill = idFirstBill;
    UPDATE BillInfo SET idBill = idFirstBill WHERE id IN (SELECT * FROM IdBillInfoTable);
    DROP TEMPORARY TABLE IdBillInfoTable;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure spTable_GetAll
-- -----------------------------------------------------

DELIMITER $$
USE `cafeteria_management`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spTable_GetAll`()
BEGIN
	SELECT * FROM TableFood;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure spTable_Insert
-- -----------------------------------------------------

DELIMITER $$
USE `cafeteria_management`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spTable_Insert`(IN nameVal VARCHAR(255))
BEGIN
	INSERT INTO TableFood(name)
    VALUES (nameVal);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- View `cafeteria_management`.`viewbillinfo`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `cafeteria_management`.`viewbillinfo`;
USE `cafeteria_management`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `cafeteria_management`.`viewbillinfo` AS select `bi`.`id` AS `ID`,`bi`.`name` AS `Món ăn`,`bi`.`Count` AS `Số lượng`,`b`.`name` AS `Tên bàn`,`b`.`status` AS `Trạng thái` from ((select `cafeteria_management`.`billinfo`.`id` AS `id`,`cafeteria_management`.`billinfo`.`idBill` AS `idBill`,`cafeteria_management`.`billinfo`.`Count` AS `Count`,`cafeteria_management`.`food`.`name` AS `name` from (`cafeteria_management`.`billinfo` join `cafeteria_management`.`food` on((`cafeteria_management`.`billinfo`.`idFood` = `cafeteria_management`.`food`.`id`)))) `bi` join (select `cafeteria_management`.`bill`.`id` AS `id`,`cafeteria_management`.`bill`.`status` AS `status`,`cafeteria_management`.`tablefood`.`name` AS `name` from (`cafeteria_management`.`bill` join `cafeteria_management`.`tablefood` on((`cafeteria_management`.`bill`.`idTable` = `cafeteria_management`.`tablefood`.`id`)))) `b` on((`bi`.`idBill` = `b`.`id`)));
USE `cafeteria_management`;

DELIMITER $$
USE `cafeteria_management`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `cafeteria_management`.`bill_AFTER_INSERT`
AFTER INSERT ON `cafeteria_management`.`bill`
FOR EACH ROW
BEGIN
	UPDATE TableFood SET status = 'Có người' WHERE id = NEW.idTable;
END$$

USE `cafeteria_management`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `cafeteria_management`.`bill_AFTER_UPDATE`
AFTER UPDATE ON `cafeteria_management`.`bill`
FOR EACH ROW
BEGIN
    DECLARE tableId INT;
    DECLARE uncheckedCount INT DEFAULT 0;
    
    SELECT idTable INTO tableId FROM Bill WHERE id = NEW.id;
    SELECT COUNT(*) INTO uncheckedCount
    FROM Bill WHERE idTable = tableId AND status = 0;
    
    IF uncheckedCount = 0 THEN
		UPDATE TableFood SET status = 'Trống' WHERE id = tableId;
	END IF;
END$$

USE `cafeteria_management`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `cafeteria_management`.`billinfo_AFTER_DELETE`
AFTER DELETE ON `cafeteria_management`.`billinfo`
FOR EACH ROW
BEGIN
	DECLARE tableId INT;
    DECLARE billInfoCount INT;
    
    SELECT idTable INTO tableId FROM Bill WHERE id = OLD.idBill AND status = 0;
    SELECT COUNT(*) INTO billInfoCount FROM BillInfo WHERE idBill = OLD.idBill;
    
    IF billInfoCount = 0 THEN
		UPDATE TableFood SET status = 'Trống' WHERE id = tableId;
	END IF;
END$$


DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
