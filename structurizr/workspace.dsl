workspace {
    model {
        customer = person "Customer"

        dispatcher = person "Dispatcher" "Responsible for order delivery control"

        admin = person "Admin"

        bank = softwareSystem "Bank" "A random bank we are working with"

        dekoffee = softwareSystem "Dekoffee" "The best coffee delivery in Kazan" {

            database = container "Database" {
                tags "db"
                technology "PostgreSQL"
            }

            inMemoryDb = container "Im-memory DB" "Cache for active payments" {
                tags "db"
                technology "Redis"
            }

            messageQuery = container "Message query" "Message query for payment and order status changes" {
                tags "db"
                technology "RabbitMQ"
            }

            paymentMicroservice = container "Payment microservice" "Microservice working with active payments and saves them in DB after completion" {
                tags "backend"
                technology "ASP.NET"

                microserviceDbContext = component "DB context" {
                    tags "dbContext"

                    this -> database "CRUD"
                }
                microservicePaymentService = component "Payment service" "The main component of microservice" {
                    tags "service"
                    
                    this -> inMemoryDb "Reads active payments"
                    this -> microserviceDbContext "CRUD"
                    this -> bank "Does transactions"
                    this -> messageQuery "Says about payment status changes"
                }
                microservicePaymentController = component "Payment controller" {
                    tags "controller"

                    this -> microservicePaymentService "Uses"
                }
            }

            mainBackend = container "Main backend microservice" "Main backend host working with almost all data. Contains regular and admin endpoints" {
                tags "backend"
                technology "ASP.NET"

                dbContext = component "DB context" {
                    tags "dbContext"

                    this -> database "CRUD"
                }

                orderStatusProducer = component "Order status producer" "A RabbitMQ message producer" {
                    tags "otherComponent"

                    this -> messageQuery "Says about order status changes"
                }

                userService = component "User service" {
                    tags "service"

                    this -> dbContext "CRUD"
                }
                authService = component "Authentication service" {
                    tags "service"
                    
                    this -> dbContext "CRUD"
                    this -> userService "Uses"
                }
                productService = component "Product service" {
                    tags "service"
                    
                    this -> dbContext "CRUD"
                }
                cartService = component "Cart service" {
                    tags "service"
                    
                    this -> dbContext "CRUD"
                    this -> userService "Uses"
                }
                productContructorService = component "Product constructor service" {
                    tags "service"
                    
                    this -> dbContext "CRUD"
                    this -> productService "Uses"
                }
                orderService = component "Order service" {
                    tags "service"

                    this -> orderStatusProducer "Says about order status changes"
                    this -> cartService "Uses"
                    this -> userService "Uses"
                }
                paymentService = component "Payment service" {
                    tags "service"
                    
                    this -> inMemoryDb "Creates payments"
                    this -> orderService "Uses"
                    this -> dbContext "Reads"
                }

                paymentStatusConsumer = component "Payment status consumer" "A RabbitMQ message consumer" {
                    tags "otherComponent"

                    this -> orderService "Uses"
                    messageQuery -> this "Consumes payment status changes"
                }

                authController = component "Authentication controller" {
                    tags "controller"

                    this -> authService "Uses"
                }
                userController = component "User controller" {
                    tags "controller"

                    this -> userService "Uses"
                }
                productController = component "Product controller" {
                    tags "controller"

                    this -> productService "Uses"
                }
                cartController = component "Cart controller" {
                    tags "controller"

                    this -> cartService "Uses"
                    this -> userService "Uses"
                }
                orderController = component "Order controller" {
                    tags "controller"

                    this -> orderService "Uses"
                    this -> paymentService "Uses"
                    this -> userService "Uses"
                }
                productContructorController = component "Product constructor controller" {
                    tags "controller"

                    this -> productContructorService "Uses"
                    this -> productService "Uses"
                    this -> userService "Uses"
                }
            }
            
            notificationMicroservice = container "Notification microservice" "Service for android notifications" {
                tags "backend"
                technology "ASP.NET"

                this -> database "Reads"
                messageQuery -> this "Consumes order status changes"
            }

            webApplication = container "Web application" "React based frontend application" {
                tags "frontend"
                technology "React"

                this -> authController "Makes HTTP requests"
                this -> userController "Makes HTTP requests"
                this -> productController "Makes HTTP requests"
                this -> cartController "Makes HTTP requests"
                this -> orderController "Makes HTTP requests"
                this -> productContructorController "Makes HTTP requests"
                this -> microservicePaymentController "Makes HTTP requests"
                customer -> this "Uses"
            }

            androidApp = container "Android application" {
                tags "frontend"
                technology "Android"

                this -> authController "Makes HTTP requests"
                this -> userController "Makes HTTP requests"
                this -> productController "Makes HTTP requests"
                this -> cartController "Makes HTTP requests"
                this -> orderController "Makes HTTP requests"
                this -> productContructorController "Makes HTTP requests"
                this -> microservicePaymentController "Makes HTTP requests"
                this -> notificationMicroservice "Connects to"
                notificationMicroservice -> this "Notifies"
                customer -> this "Uses"
            }

            adminApplication = container "Admin application" "React based admin UI" {
                tags "frontend"
                technology "React"

                this -> mainBackend "Makes HTTP requests"
                dispatcher -> this "Uses"
                admin -> this "Uses"
            }
        }

    }

    views {
        styles {
            element backend {
                shape hexagon
                background #555555
            }
            element db {
                shape cylinder
                background #30AA30
            }
            element frontend {
                shape webBrowser
            }

            element dbContext {
                background #006400
            }
            element service {
                background #0096FF
            }
            element controller {
                background #FF4C4C
            }
            element otherComponent {
                background #999999
            }
        }

        systemContext dekoffee {
            include *
        }

        container dekoffee {
            include *
        }

        component mainBackend {
            include *
        }
        component paymentMicroservice {
            include *
        }

        theme default
    }
}
