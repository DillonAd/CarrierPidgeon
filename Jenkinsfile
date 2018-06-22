pipeline {
    agent any
    
    stages {
        stage('Build') {
            steps {
                checkout scm
                sh 'dotnet build ./CarrierPidgeon.sln'
                stash "${BUILD_NUMBER}"
            }
        }
        stage('Unit Test') {

            sh 'dotnet /opt/sonarscanner-msbuild/SonarScanner.MSBuild.dll begin /k:"carrierPidgeon" /d:sonar.tests="./CarrierPidgeon.Test/" /d:sonar.exclusions="./CarrierPidgeon.Test/" /d:sonar.test.inclusions="./CarrierPidgeon.Test/"'

            try
            {
                steps {
                    unstash "${BUILD_NUMBER}"
                    
                    sh 'dotnet build ./CarrierPidgeon.sln'
                    sh 'dotnet test ./CarrierPidgeon.Test/CarrierPidgeon.Test.csproj --filter Category=unit --logger "trx;LogFileName=results\\tests_unit.xml" --collect "Code Coverage" --no-build'
                    
                    stash "${BUILD_NUMBER}"
                }
            }
            catch (ex) {
                throw
            }
            finally {
                sh 'dotnet /opt/sonarscanner-msbuild/SonarScanner.MSBuild.dll end'
            }
        }
    }
}