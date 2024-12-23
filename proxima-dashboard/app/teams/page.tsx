import { Header } from "@/components/header"
import { Sidebar } from "@/components/sidebar"
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import { Button } from "@/components/ui/button"
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar"
import { Badge } from "@/components/ui/badge"
import { PlusCircle } from 'lucide-react'

export default function TeamsPage() {
  const teams = [
    {
      id: 1,
      name: "Product Development",
      members: [
        { name: "John Doe", role: "Team Lead", avatar: "/placeholder.svg" },
        { name: "Jane Smith", role: "Developer", avatar: "/placeholder.svg" },
        { name: "Mike Johnson", role: "Designer", avatar: "/placeholder.svg" },
      ],
      projectCount: 3,
    },
    {
      id: 2,
      name: "Marketing",
      members: [
        { name: "Sarah Williams", role: "Marketing Manager", avatar: "/placeholder.svg" },
        { name: "Tom Brown", role: "Content Creator", avatar: "/placeholder.svg" },
      ],
      projectCount: 2,
    },
    {
      id: 3,
      name: "Customer Support",
      members: [
        { name: "Emily Davis", role: "Support Lead", avatar: "/placeholder.svg" },
        { name: "Chris Wilson", role: "Support Agent", avatar: "/placeholder.svg" },
        { name: "Alex Lee", role: "Support Agent", avatar: "/placeholder.svg" },
      ],
      projectCount: 1,
    },
  ]

  return (
    <div className="flex min-h-screen bg-gray-50">
      <Sidebar />
      <div className="flex-1 flex flex-col pl-16">
        <Header />
        <main className="flex-1 overflow-x-auto p-6">
          <div className="max-w-7xl mx-auto space-y-6">
            <div className="flex justify-between items-center">
              <h1 className="text-2xl font-semibold text-gray-900">Teams</h1>
              <Button>
                <PlusCircle className="mr-2 h-4 w-4" />
                Create New Team
              </Button>
            </div>
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
              {teams.map((team) => (
                <Card key={team.id}>
                  <CardHeader>
                    <CardTitle>{team.name}</CardTitle>
                  </CardHeader>
                  <CardContent>
                    <div className="space-y-4">
                      <div className="flex items-center space-x-2">
                        {team.members.slice(0, 3).map((member, index) => (
                          <Avatar key={index} className="h-8 w-8">
                            <AvatarImage src={member.avatar} alt={member.name} />
                            <AvatarFallback>{member.name.split(' ').map(n => n[0]).join('')}</AvatarFallback>
                          </Avatar>
                        ))}
                        {team.members.length > 3 && (
                          <div className="flex items-center justify-center h-8 w-8 rounded-full bg-gray-200 text-xs font-medium text-gray-600">
                            +{team.members.length - 3}
                          </div>
                        )}
                      </div>
                      <div className="flex justify-between items-center">
                        <span className="text-sm text-gray-500">{team.members.length} members</span>
                        <Badge variant="secondary">{team.projectCount} projects</Badge>
                      </div>
                      <Button variant="outline" className="w-full">View Team</Button>
                    </div>
                  </CardContent>
                </Card>
              ))}
            </div>
          </div>
        </main>
      </div>
    </div>
  )
}

