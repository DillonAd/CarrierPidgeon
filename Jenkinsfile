pipeline {
    agent any
    
    stages {
        stage('Start SonarQube') {
            steps {
                checkout scm
                sh 'dotnet /opt/sonarscanner-msbuild/SonarScanner.MSBuild.dll begin /k:"carrierPidgeon" /d:sonar.tests="./CarrierPidgeon.Test/" /d:sonar.exclusions="./CarrierPidgeon.Test/" /d:sonar.test.inclusions="./CarrierPidgeon.Test/" /d:sonar.scm.provider="git"'
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
                        sh 'dotnet /opt/sonarscanner-msbuild/SonarScanner.MSBuild.dll end'
                        throw ex
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
                        sh "dotnet test ./CarrierPidgeon.Tests/CarrierPidgeon.Tests.csproj --logger \"trx;LogFileName=unit_tests.xml\" /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=./lcov --no-build"
            			step([$class: 'MSTestPublisher', testResultsFile:"**/unit_tests.xml", failOnError: true, keepLongStdio: true])
                    } finally {
                        sh 'dotnet /opt/sonarscanner-msbuild/SonarScanner.MSBuild.dll end'
                    }
                }
            }
        }
    }
}