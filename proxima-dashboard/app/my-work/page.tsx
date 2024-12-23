import { Header } from "@/components/header"
import { Sidebar } from "@/components/sidebar"
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import { Badge } from "@/components/ui/badge"
import { Button } from "@/components/ui/button"
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar"
import { PlusCircle, Calendar, FileText, CheckCircle2 } from 'lucide-react'

export default function MyWorkPage() {
  const tasks = [
    { id: 1, title: "Review project proposal", dueDate: "Today", priority: "High", status: "In Progress" },
    { id: 2, title: "Update client presentation", dueDate: "Tomorrow", priority: "Medium", status: "Not Started" },
    { id: 3, title: "Team meeting prep", dueDate: "Oct 15", priority: "Low", status: "Completed" },
  ]

  return (
    <div className="flex min-h-screen bg-gray-50">
      <Sidebar />
      <div className="flex-1 flex flex-col pl-16">
        <Header />
        <main className="flex-1 overflow-x-auto p-6">
          <div className="max-w-6xl mx-auto space-y-6">
            <div className="flex justify-between items-center">
              <h1 className="text-2xl font-semibold text-gray-900">My Work</h1>
              <Button>
                <PlusCircle className="mr-2 h-4 w-4" />
                Add Task
              </Button>
            </div>
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
              <Card>
                <CardHeader>
                  <CardTitle>Tasks</CardTitle>
                </CardHeader>
                <CardContent>
                  <ul className="space-y-4">
                    {tasks.map((task) => (
                      <li key={task.id} className="flex items-start space-x-4">
                        <div className="flex-shrink-0">
                          <CheckCircle2 className="h-6 w-6 text-blue-500" />
                        </div>
                        <div className="flex-1 min-w-0">
                          <p className="text-sm font-medium text-gray-900 truncate">{task.title}</p>
                          <div className="flex items-center space-x-2 mt-1">
                            <Badge variant="secondary">{task.priority}</Badge>
                            <Badge variant={task.status === "Completed" ? "success" : "default"}>{task.status}</Badge>
                          </div>
                        </div>
                        <div className="flex-shrink-0 text-sm text-gray-500">{task.dueDate}</div>
                      </li>
                    ))}
                  </ul>
                </CardContent>
              </Card>
              <Card>
                <CardHeader>
                  <CardTitle>Upcoming Deadlines</CardTitle>
                </CardHeader>
                <CardContent>
                  <ul className="space-y-4">
                    <li className="flex items-center space-x-3">
                      <Calendar className="h-5 w-5 text-blue-500" />
                      <span className="text-sm">Project X Milestone - Oct 20</span>
                    </li>
                    <li className="flex items-center space-x-3">
                      <Calendar className="h-5 w-5 text-blue-500" />
                      <span className="text-sm">Quarterly Report Due - Oct 31</span>
                    </li>
                  </ul>
                </CardContent>
              </Card>
              <Card>
                <CardHeader>
                  <CardTitle>Recent Documents</CardTitle>
                </CardHeader>
                <CardContent>
                  <ul className="space-y-4">
                    <li className="flex items-center space-x-3">
                      <FileText className="h-5 w-5 text-blue-500" />
                      <span className="text-sm">Q3 Performance Review.docx</span>
                    </li>
                    <li className="flex items-center space-x-3">
                      <FileText className="h-5 w-5 text-blue-500" />
                      <span className="text-sm">Project Proposal v2.pptx</span>
                    </li>
                  </ul>
                </CardContent>
              </Card>
            </div>
            <Card>
              <CardHeader>
                <CardTitle>Team Activity</CardTitle>
              </CardHeader>
              <CardContent>
                <ul className="space-y-4">
                  <li className="flex items-start space-x-3">
                    <Avatar className="h-8 w-8">
                      <AvatarImage src="/placeholder.svg" alt="Team member" />
                      <AvatarFallback>TM</AvatarFallback>
                    </Avatar>
                    <div>
                      <p className="text-sm font-medium">Jane Doe commented on Project Y</p>
                      <p className="text-xs text-gray-500">2 hours ago</p>
                    </div>
                  </li>
                  <li className="flex items-start space-x-3">
                    <Avatar className="h-8 w-8">
                      <AvatarImage src="/placeholder.svg" alt="Team member" />
                      <AvatarFallback>JM</AvatarFallback>
                    </Avatar>
                    <div>
                      <p className="text-sm font-medium">John Smith updated Task Z</p>
                      <p className="text-xs text-gray-500">5 hours ago</p>
                    </div>
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

