pipeline {
    agent any

    environment {
        DOTNET_CLI_HOME = "C:\\Program Files\\dotnet"
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Build') {
            steps {
                script {
                    // Restoring dependencies
                    //bat "cd ${DOTNET_CLI_HOME} && dotnet restore"
                    bat "dotnet restore"

                    // Building the application
                    bat "dotnet build --configuration Release"
                }
            }
        }

        stage('Test') {
            steps {
                script {
                    // Running tests
                    bat "dotnet test --no-restore --configuration Release"
                }
            }
        }

        stage('Publish') {
            steps {
                script {
                    // Publishing the application
                    bat "dotnet publish --no-restore --configuration Release --output .\\publish"
                }
            }
        }
    }

   post {
        always {
            script {
                // Capture and send console output
                def consoleOutput = currentBuild.rawBuild.getLog(1000).join('\n')
                emailext (
                    subject: "Build ${currentBuild.fullDisplayName} - ${currentBuild.currentResult}",
                    body: """
                        <p>Build Status: ${currentBuild.currentResult}</p>
                        <pre>${consoleOutput}</pre>
                    """,
                    mimeType: 'text/html',
                    to: 'divyani.jain12627@gmail.com'
                )
            }
        }
    }
}
