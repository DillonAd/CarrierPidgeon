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
                        sh 'dotnet test ./CarrierPidgeon.Test/CarrierPidgeon.Test.csproj --filter Category=unit --logger "trx;LogFileName=results\\tests_unit.xml" --collect "Code Coverage" --no-build'
                    } finally {
                        sh 'dotnet /opt/sonarscanner-msbuild/SonarScanner.MSBuild.dll end'
                    }
                }
            }
        }
    }
}