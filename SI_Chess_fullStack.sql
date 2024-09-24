set search_path to personalInfo;

CREATE TABLE personalInfo.persons (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    DateOfBirth DATE NOT NULL,
    ResidentialAddress VARCHAR(255) NOT NULL,
    PermanentAddress VARCHAR(255) NOT NULL,
    PhoneNumber VARCHAR(15) NOT NULL,
    EmailAddress VARCHAR(100) NOT NULL UNIQUE,
    MaritalStatus VARCHAR(20) NOT NULL,
    Gender VARCHAR(10) NOT NULL CHECK (Gender IN ('Male', 'Female', 'Other')),
    Occupation VARCHAR(50),
    AadharCardNumber VARCHAR(12) NOT NULL UNIQUE,
    PanNumber VARCHAR(10) NOT NULL UNIQUE
);

INSERT INTO personalInfo.persons (
    Name, 
    DateOfBirth, 
    ResidentialAddress, 
    PermanentAddress, 
    PhoneNumber, 
    EmailAddress, 
    MaritalStatus, 
    Gender, 
    Occupation, 
    AadharCardNumber, 
    PanNumber
) VALUES
('John Doe',                     '1990-01-01', '123 Main St, City, State', '456 Elm St, City, State', '9876543210', 'johndoe@example.com', 'Single', 'Male', 'Software Developer', '123456789012', 'ABCDE1234F'),
('Jane Smith',                   '1985-05-15', '789 Pine St, City, State', '101 Maple St, City, State', '9123456780', 'janesmith@example.com', 'Married', 'Female', 'Graphic Designer', '234567890123', 'FGHIJ2345G'),
('Alice Johnson',                '1992-11-20', '456 Oak St, City, State', '789 Birch St, City, State', '9988776655', 'alice.johnson@example.com', 'Single', 'Female', 'Data Scientist', '345678901234', 'JKLMN3456H'),
('Bob Brown',                    '1980-02-28', '321 Cedar St, City, State', '654 Spruce St, City, State', '7654321098', 'bobbrown@example.com', 'Divorced', 'Male', 'Project Manager', '456789012345', 'NOPQR4567J'),
('Charlie White',                '1995-08-12', '111 Cherry St, City, State', '222 Walnut St, City, State', '1234567890', 'charlie.white@example.com', 'Single', 'Male', 'Web Developer', '567890123456', 'STUVW5678K'),
('Eve Davis',                    '1993-03-30', '333 Willow St, City, State', '444 Aspen St, City, State', '2345678901', 'eve.davis@example.com', 'Married', 'Female', 'Marketing Manager', '678901234567', 'XYZAB6789L'),
('David Wilson',                 '1988-12-05', '555 Chestnut St, City, State', '666 Hazel St, City, State', '3456789012', 'david.wilson@example.com', 'Single', 'Male', 'Accountant', '789012345678', 'ABCDE9876M'),
('Grace Taylor',                 '1991-07-19', '777 Fir St, City, State', '888 Pine St, City, State', '4567890123', 'grace.taylor@example.com', 'Engaged', 'Female', 'HR Specialist', '890123456789', 'FGHIJ1234N'),
('Michael Brown',                '1987-10-10', '999 Larch St, City, State', '000 Cedar St, City, State', '5678901234', 'michael.brown@example.com', 'Single', 'Male', 'Systems Analyst', '901234567890', 'JKLMN3456O');

select * from persons;
