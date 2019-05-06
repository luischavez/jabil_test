USE Materials;

INSERT INTO Buildings
    (Building, Available)
VALUES
       ('Building1', 1),
       ('Building2', 1),
       ('Building3', 0);

INSERT INTO Customers
    (Customer, Prefix, FKBuilding, Available)
VALUES
       ('Luis', 'cust1', 1, 1),
       ('Pedro', 'cust2', 1, 1),
       ('Juan', 'cust3', 2, 0),
       ('David', 'cust4', 3, 1);

INSERT INTO PartNumbers
    (PartNumber, FKCustomer, Available)
VALUES
    ('P1234', 1, 0),
    ('P3523', 2, 1),
    ('P5342', 3, 1),
    ('P6234', 4, 1);
