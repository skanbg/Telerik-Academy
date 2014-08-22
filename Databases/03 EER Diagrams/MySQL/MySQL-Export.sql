SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema TelerikUniversity
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `TelerikUniversity` ;
CREATE SCHEMA IF NOT EXISTS `TelerikUniversity` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `TelerikUniversity` ;

-- -----------------------------------------------------
-- Table `TelerikUniversity`.`Faculties`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TelerikUniversity`.`Faculties` ;

CREATE TABLE IF NOT EXISTS `TelerikUniversity`.`Faculties` (
  `FacultyID` INT NOT NULL AUTO_INCREMENT,
  `FacultyName` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`FacultyID`),
  UNIQUE INDEX `FacultyID_UNIQUE` (`FacultyID` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TelerikUniversity`.`Departments`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TelerikUniversity`.`Departments` ;

CREATE TABLE IF NOT EXISTS `TelerikUniversity`.`Departments` (
  `DepartmentID` INT NOT NULL AUTO_INCREMENT,
  `DepartmentName` VARCHAR(45) NOT NULL,
  `FacultyID` INT NOT NULL,
  PRIMARY KEY (`DepartmentID`),
  UNIQUE INDEX `DepartmentID_UNIQUE` (`DepartmentID` ASC),
  INDEX `fk_Departments_Faculties_idx` (`FacultyID` ASC),
  CONSTRAINT `fk_Departments_Faculties`
    FOREIGN KEY (`FacultyID`)
    REFERENCES `TelerikUniversity`.`Faculties` (`FacultyID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TelerikUniversity`.`Students`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TelerikUniversity`.`Students` ;

CREATE TABLE IF NOT EXISTS `TelerikUniversity`.`Students` (
  `StudentID` INT NOT NULL AUTO_INCREMENT,
  `StudentName` VARCHAR(45) NOT NULL,
  `FacultyID` INT NOT NULL,
  PRIMARY KEY (`StudentID`),
  UNIQUE INDEX `StudentID_UNIQUE` (`StudentID` ASC),
  INDEX `fk_Students_Faculties1_idx` (`FacultyID` ASC),
  CONSTRAINT `fk_Students_Faculties1`
    FOREIGN KEY (`FacultyID`)
    REFERENCES `TelerikUniversity`.`Faculties` (`FacultyID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TelerikUniversity`.`Courses`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TelerikUniversity`.`Courses` ;

CREATE TABLE IF NOT EXISTS `TelerikUniversity`.`Courses` (
  `CourseID` INT NOT NULL AUTO_INCREMENT,
  `CourseName` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`CourseID`),
  UNIQUE INDEX `CourseID_UNIQUE` (`CourseID` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TelerikUniversity`.`StudentsCourseEnrollment`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TelerikUniversity`.`StudentsCourseEnrollment` ;

CREATE TABLE IF NOT EXISTS `TelerikUniversity`.`StudentsCourseEnrollment` (
  `StudentID` INT NOT NULL,
  `CourseID` INT NOT NULL,
  PRIMARY KEY (`StudentID`, `CourseID`),
  INDEX `fk_StudentsCourseEnrollment_Courses1_idx` (`CourseID` ASC),
  CONSTRAINT `fk_StudentsCourseEnrollment_Students1`
    FOREIGN KEY (`StudentID`)
    REFERENCES `TelerikUniversity`.`Students` (`StudentID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_StudentsCourseEnrollment_Courses1`
    FOREIGN KEY (`CourseID`)
    REFERENCES `TelerikUniversity`.`Courses` (`CourseID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TelerikUniversity`.`Professor`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TelerikUniversity`.`Professor` ;

CREATE TABLE IF NOT EXISTS `TelerikUniversity`.`Professor` (
  `ProfessorID` INT NOT NULL AUTO_INCREMENT,
  `ProfessorName` VARCHAR(45) NULL,
  PRIMARY KEY (`ProfessorID`),
  UNIQUE INDEX `ProfessorID_UNIQUE` (`ProfessorID` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TelerikUniversity`.`UniversityCoursesProgram`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TelerikUniversity`.`UniversityCoursesProgram` ;

CREATE TABLE IF NOT EXISTS `TelerikUniversity`.`UniversityCoursesProgram` (
  `CourseID` INT NOT NULL AUTO_INCREMENT,
  `ProfessorID` INT NOT NULL,
  PRIMARY KEY (`CourseID`),
  UNIQUE INDEX `CourseID_UNIQUE` (`CourseID` ASC),
  INDEX `fk_UniversityCoursesProgram_Professor1_idx` (`ProfessorID` ASC),
  CONSTRAINT `fk_UniversityCoursesProgram_Courses1`
    FOREIGN KEY (`CourseID`)
    REFERENCES `TelerikUniversity`.`Courses` (`CourseID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_UniversityCoursesProgram_Professor1`
    FOREIGN KEY (`ProfessorID`)
    REFERENCES `TelerikUniversity`.`Professor` (`ProfessorID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TelerikUniversity`.`AcademicalTitles`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TelerikUniversity`.`AcademicalTitles` ;

CREATE TABLE IF NOT EXISTS `TelerikUniversity`.`AcademicalTitles` (
  `TitleID` INT NOT NULL AUTO_INCREMENT,
  `TitleName` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`TitleID`),
  UNIQUE INDEX `TitleID_UNIQUE` (`TitleID` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TelerikUniversity`.`ProfessorTitles`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TelerikUniversity`.`ProfessorTitles` ;

CREATE TABLE IF NOT EXISTS `TelerikUniversity`.`ProfessorTitles` (
  `ProfessorID` INT NOT NULL,
  `AcademicalTitleID` INT NULL,
  PRIMARY KEY (`ProfessorID`),
  INDEX `fk_ProfessorTitles_AcademicalTitles1_idx` (`AcademicalTitleID` ASC),
  CONSTRAINT `fk_ProfessorTitles_Professor1`
    FOREIGN KEY (`ProfessorID`)
    REFERENCES `TelerikUniversity`.`Professor` (`ProfessorID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ProfessorTitles_AcademicalTitles1`
    FOREIGN KEY (`AcademicalTitleID`)
    REFERENCES `TelerikUniversity`.`AcademicalTitles` (`TitleID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
