import { Header } from "@/components/header"
import { Sidebar } from "@/components/sidebar"
import { Card, CardContent } from "@/components/ui/card"
import { Badge } from "@/components/ui/badge"
import { Button } from "@/components/ui/button"
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar"
import { PlusCircle } from 'lucide-react'

export default function TimelinePage() {
  const timelineEvents = [
    { id: 1, title: "Project Kickoff", date: "Oct 1, 2023", description: "Initial meeting and project planning", user: { name: "John Doe", avatar: "/placeholder.svg" } },
    { id: 2, title: "Design Phase Completed", date: "Oct 15, 2023", description: "Finalized UI/UX designs", user: { name: "Jane Smith", avatar: "/placeholder.svg" } },
    { id: 3, title: "Development Sprint 1", date: "Oct 22, 2023", description: "Completed core functionality", user: { name: "Mike Johnson", avatar: "/placeholder.svg" } },
    { id: 4, title: "Client Review", date: "Nov 5, 2023", description: "Presented progress to the client", user: { name: "Sarah Williams", avatar: "/placeholder.svg" } },
  ]

  return (
    <div className="flex min-h-screen bg-gray-50">
      <Sidebar />
      <div className="flex-1 flex flex-col pl-16">
        <Header />
        <main className="flex-1 overflow-x-auto p-6">
          <div className="max-w-4xl mx-auto space-y-6">
            <div className="flex justify-between items-center">
              <h1 className="text-2xl font-semibold text-gray-900">Project Timeline</h1>
              <Button>
                <PlusCircle className="mr-2 h-4 w-4" />
                Add Event
              </Button>
            </div>
            <Card>
              <CardContent className="p-6">
                <ol className="relative border-l border-gray-200 dark:border-gray-700">
                  {timelineEvents.map((event, index) => (
                    <li key={event.id} className="mb-10 ml-6">
                      <span className="absolute flex items-center justify-center w-6 h-6 bg-blue-100 rounded-full -left-3 ring-8 ring-white dark:ring-gray-900 dark:bg-blue-900">
                        <Badge variant="secondary">{index + 1}</Badge>
                      </span>
                      <div className="flex items-center mb-1 space-x-3">
                        <h3 className="text-lg font-semibold text-gray-900 dark:text-white">{event.title}</h3>
                        <span className="bg-blue-100 text-blue-800 text-sm font-medium mr-2 px-2.5 py-0.5 rounded dark:bg-blue-900 dark:text-blue-300">{event.date}</span>
                      </div>
                      <p className="mb-4 text-base font-normal text-gray-500 dark:text-gray-400">{event.description}</p>
                      <div className="flex items-center space-x-2">
                        <Avatar className="h-8 w-8">
                          <AvatarImage src={event.user.avatar} alt={event.user.name} />
                          <AvatarFallback>{event.user.name.split(' ').map(n => n[0]).join('')}</AvatarFallback>
                        </Avatar>
                        <span className="text-sm text-gray-500">{event.user.name}</span>
                      </div>
                    </li>
                  ))}
                </ol>
              </CardContent>
            </Card>
          </div>
        </main>
      </div>
    </div>
  )
}

