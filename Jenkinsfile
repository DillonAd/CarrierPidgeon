pipeline {
    agent any
    
    stages {
        stage('Build') {
            steps {
                checkout scm
                sh 'dotnet /opt/sonarscanner-msbuild/SonarScanner.MSBuild.dll begin /k:"carrierPidgeon"'
                sh 'dotnet build ./CarrierPidgeon/CarrierPidgeon.csproj --output ./out'
                sh 'dotnet /opt/sonarscanner-msbuild/SonarScanner.MSBuild.dll end'
                stash "${BUILD_NUMBER}"
            }
        }
        //stage('Unit Test') {
        //    steps {
        //        unstash "${BUILD_NUMBER}"
        //        sh 'dotnet test ./CarrierPidgeon.Test/CarrierPidgeon.Test.csproj --filter Category=unit --logger "trx;LogFileName=results\\tests_unit.xml"'
        //        sh 'dotnet /opt/sonarscanner-msbuild/SonarScanner.MSBuild.dll end'
        //        stash "${BUILD_NUMBER}"
        //    }
        //}
    }
}