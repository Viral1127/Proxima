import { Header } from "@/components/header"
import { Sidebar } from "@/components/sidebar"
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import { Button } from "@/components/ui/button"
import { ProjectStats } from "@/components/project-stats"
import { BarChart, FileText, PieChart, PlusCircle } from 'lucide-react'

export default function ReportsPage() {
  return (
    <div className="flex min-h-screen bg-gray-50">
      <Sidebar />
      <div className="flex-1 flex flex-col pl-16">
        <Header />
        <main className="flex-1 overflow-x-auto p-6">
          <div className="max-w-7xl mx-auto space-y-6">
            <div className="flex justify-between items-center">
              <h1 className="text-2xl font-semibold text-gray-900">Reports</h1>
              <Button>
                <PlusCircle className="mr-2 h-4 w-4" />
                Generate New Report
              </Button>
            </div>
            <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
              <Card>
                <CardHeader>
                  <CardTitle>Project Performance</CardTitle>
                </CardHeader>
                <CardContent className="h-[300px]">
                  <ProjectStats />
                </CardContent>
              </Card>
              <Card>
                <CardHeader>
                  <CardTitle>Task Distribution</CardTitle>
                </CardHeader>
                <CardContent className="h-[300px] flex items-center justify-center">
                  <PieChart className="h-64 w-64 text-blue-500" />
                </CardContent>
              </Card>
            </div>
            <Card>
              <CardHeader>
                <CardTitle>Recent Reports</CardTitle>
              </CardHeader>
              <CardContent>
                <ul className="space-y-4">
                  <li className="flex items-center space-x-3">
                    <FileText className="h-5 w-5 text-blue-500" />
                    <span className="text-sm">Q3 Performance Report</span>
                    <Badge variant="outline">PDF</Badge>
                  </li>
                  <li className="flex items-center space-x-3">
                    <FileText className="h-5 w-5 text-blue-500" />
                    <span className="text-sm">Project X Progress Report</span>
                    <Badge variant="outline">XLSX</Badge>
                  </li>
                  <li className="flex items-center space-x-3">
                    <FileText className="h-5 w-5 text-blue-500" />
                    <span className="text-sm">Annual Financial Summary</span>
                    <Badge variant="outline">PDF</Badge>
                  </li>
                </ul>
              </CardContent>
            </Card>
          </div>
        </main>
      </div>
    </div>
  )
}

