workspace {
    model {
        customer = person "Customer" {
            tags "user"
        }

        bank = softwareSystem "Bank"

        dekoffee = softwareSystem "Dekoffee" {

            database = container "Database" {
                tags "db"
                technology "PostgreSQL"
            }

            inMemoryDb = container "Im-memory DB" "Cash for active payments" {
                tags "db"
                technology "Redis"
            }

            messageQuery = container "Message query" {
                tags "db"
                technology "RabbitMQ"
            }

            paymentMicroservice = container "Payment microservice" {
                tags "backend"
                technology "ASP.NET"
                this -> database "CRUD"
                this -> inMemoryDb "Reads payments"
                this -> bank "Does transactions"
                this -> messageQuery "Says about payment status changes"
            }

            mainBackend = container "Main backend microervice" {
                tags "backend"
                technology "ASP.NET"
                this -> database "CRUD"
                this -> inMemoryDb "Creates payments"
                this -> messageQuery "Says about order status changes"
                messageQuery -> this "Consumes payment status changes"
            }
            
            notificationMicroservice = container "Notification microservice" {
                tags "backend"
                technology "ASP.NET"
                this -> database "Reads"
                messageQuery -> this "Consumes order status changes"
            }

            webApplication = container "Web application" {
                tags "frontend"
                technology "React"
                this -> mainBackend "Makes HTTP requests"
                this -> paymentMicroservice "Makes HTTP requests"
                customer -> this "Uses"
            }

            androidApp = container "Android application" {
                tags "frontend"
                technology "Android"
                this -> mainBackend "Makes HTTP requests"
                this -> paymentMicroservice "Makes HTTP requests"
                this -> notificationMicroservice "Connects"
                notificationMicroservice -> this "Notifies"
                customer -> this "Uses"
            }

            adminApplication = container "Admin application" {
                tags "frontend"
                technology "React"
                this -> mainBackend "Makes HTTP requests"
                customer -> this "Uses"
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
            
            element side {
                shape box
                background #707070
            }
        }

        systemContext dekoffee {
            include *
            autolayout lr
        }

        container dekoffee {
            include *
            autolayout lr
        }

        theme default
    }
}
