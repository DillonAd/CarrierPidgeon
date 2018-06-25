pipeline {
    agent any
    
    stages {
        stage('Start SonarQube') {
            steps {
                checkout scm
                sh 'dotnet /opt/sonarscanner-msbuild/SonarScanner.MSBuild.dll begin /k:"carrierPidgeon" /d:sonar.tests="./CarrierPidgeon.Test/" /d:sonar.exclusions="./CarrierPidgeon.Test/" /d:sonar.test.inclusions="./CarrierPidgeon.Test/"'
                stash "${BUILD_NUMBER}"
            }
        }
        stage('Build') {
            steps {
                script {
                    unstash "${BUILD_NUMBER}"
                    try
                    { 
                        sh 'dotnet build ./CarrierPidgeon.sln'
                    } catch(ex) {
                        throw ex
                    } finally {
                        sh 'dotnet /opt/sonarscanner-msbuild/SonarScanner.MSBuild.dll end'
                    }
                    stash "${BUILD_NUMBER}"
                }
            }
        }
        stage('Test') {
            steps {
                script {
                    unstash "${BUILD_NUMBER}"
                    try
                    { 
                        sh "dotnet test ./CarrierPidgeon.Test/CarrierPidgeon.Test.csproj --logger \"trx;LogFileName=unit_tests.xml\" --no-build"
            			step([$class: 'MSTestPublisher', testResultsFile:"**/unit_tests.xml", failOnError: true, keepLongStdio: true])
                    } finally {
                        sh 'dotnet /opt/sonarscanner-msbuild/SonarScanner.MSBuild.dll end'
                    }
                }
            }
        }
    }
}