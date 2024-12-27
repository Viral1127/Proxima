import { Header } from "@/components/header"
import { Sidebar } from "@/components/sidebar"
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Badge } from "@/components/ui/badge"
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar"
import { FileText, PlusCircle, Search } from 'lucide-react'

export default function DocumentsPage() {
  const documents = [
    { id: 1, name: "Project Proposal.docx", type: "Word", size: "2.3 MB", lastModified: "2023-10-15", author: { name: "John Doe", avatar: "/placeholder.svg" } },
    { id: 2, name: "Financial Report Q3.xlsx", type: "Excel", size: "1.5 MB", lastModified: "2023-10-10", author: { name: "Jane Smith", avatar: "/placeholder.svg" } },
    { id: 3, name: "Meeting Minutes.pdf", type: "PDF", size: "567 KB", lastModified: "2023-10-05", author: { name: "Mike Johnson", avatar: "/placeholder.svg" } },
    { id: 4, name: "Product Roadmap.pptx", type: "PowerPoint", size: "3.1 MB", lastModified: "2023-09-30", author: { name: "Sarah Williams", avatar: "/placeholder.svg" } },
  ]

  return (
    <div className="flex min-h-screen bg-gray-50">
      <Sidebar />
      <div className="flex-1 flex flex-col pl-16">
        <Header />
        <main className="flex-1 overflow-x-auto p-6">
          <div className="max-w-7xl mx-auto space-y-6">
            <div className="flex justify-between items-center">
              <h1 className="text-2xl font-semibold text-gray-900">Documents</h1>
              <Button>
                <PlusCircle className="mr-2 h-4 w-4" />
                Upload Document
              </Button>
            </div>
            <div className="flex items-center space-x-2">
              <Search className="h-5 w-5 text-gray-400" />
              <Input
                type="search"
                placeholder="Search documents..."
                className="max-w-sm"
              />
            </div>
            <Card>
              <CardHeader>
                <CardTitle>Recent Documents</CardTitle>
              </CardHeader>
              <CardContent>
                <table className="w-full">
                  <thead>
                    <tr className="text-left text-sm text-gray-500">
                      <th className="pb-2">Name</th>
                      <th className="pb-2">Type</th>
                      <th className="pb-2">Size</th>
                      <th className="pb-2">Last Modified</th>
                      <th className="pb-2">Author</th>
                    </tr>
                  </thead>
                  <tbody>
                    {documents.map((doc) => (
                      <tr key={doc.id} className="border-t border-gray-200">
                        <td className="py-3 flex items-center space-x-2">
                          <FileText className="h-5 w-5 text-blue-500" />
                          <span>{doc.name}</span>
                        </td>
                        <td className="py-3">
                          <Badge variant="secondary">{doc.type}</Badge>
                        </td>
                        <td className="py-3 text-sm text-gray-500">{doc.size}</td>
                        <td className="py-3 text-sm text-gray-500">{doc.lastModified}</td>
                        <td className="py-3">
                          <div className="flex items-center space-x-2">
                            <Avatar className="h-6 w-6">
                              <AvatarImage src={doc.author.avatar} alt={doc.author.name} />
                              <AvatarFallback>{doc.author.name.split(' ').map(n => n[0]).join('')}</AvatarFallback>
                            </Avatar>
                            <span className="text-sm text-gray-700">{doc.author.name}</span>
                          </div>
                        </td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              </CardContent>
            </Card>
          </div>
        </main>
      </div>
    </div>
  )
}

