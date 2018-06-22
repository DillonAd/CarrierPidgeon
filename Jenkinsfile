pipeline {
    agent any
    
    stages {
        stage('Build') {
            steps {
                script {
                    try
                    {
                        checkout scm
                        sh 'dotnet /opt/sonarscanner-msbuild/SonarScanner.MSBuild.dll begin /k:"carrierPidgeon" /d:sonar.tests="./CarrierPidgeon.Test/" /d:sonar.exclusions="./CarrierPidgeon.Test/" /d:sonar.test.inclusions="./CarrierPidgeon.Test/"'

                        sh 'dotnet build ./CarrierPidgeon.sln'
                    
                        sh 'dotnet test ./CarrierPidgeon.Test/CarrierPidgeon.Test.csproj --filter Category=unit --logger "trx;LogFileName=results\\tests_unit.xml" --collect "Code Coverage" --no-build'
                    }
                    catch (ex) {
                        throw ex
                    }
                    finally {
                        sh 'dotnet /opt/sonarscanner-msbuild/SonarScanner.MSBuild.dll end'
                    }
                }
            }
        }
    }
}