import { Header } from "@/components/header"
import { Sidebar } from "@/components/sidebar"
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Card, CardHeader, CardTitle, CardDescription, CardContent, CardFooter } from "@/components/ui/card"
import { Table, TableHeader, TableBody, TableFooter, TableHead, TableRow, TableCell } from "@/components/ui/table"
import { LoginForm } from "@/components/login-form"
import { RegistrationForm } from "@/components/registration-form"
import Link from 'next/link'

export default function TemplateDemoPage() {
  return (
    <div className="flex min-h-screen bg-gray-50">
      <Sidebar />
      <div className="flex-1 flex flex-col pl-16">
        <Header />
        <main className="flex-1 overflow-x-auto p-6">
          <div className="max-w-7xl mx-auto space-y-6">
            <h1 className="text-3xl font-semibold mb-6">Template Demo</h1>

            {/* Button Examples */}
            <section>
              <h2 className="text-2xl font-semibold mb-4">Buttons</h2>
              <div className="flex flex-wrap gap-4">
                <Button>Default Button</Button>
                <Button variant="secondary">Secondary Button</Button>
                <Button variant="outline">Outline Button</Button>
                <Button variant="ghost">Ghost Button</Button>
                <Button variant="link">Link Button</Button>
              </div>
            </section>

            {/* Input Examples */}
            <section>
              <h2 className="text-2xl font-semibold mb-4">Inputs</h2>
              <div className="flex flex-col gap-4 max-w-md">
                <Input type="text" placeholder="Text input" />
                <Input type="email" placeholder="Email input" />
                <Input type="password" placeholder="Password input" />
              </div>
            </section>

            {/* Card Examples */}
            <section>
              <h2 className="text-2xl font-semibold mb-4">Cards</h2>
              <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
                <Card>
                  <CardHeader>
                    <CardTitle>Card Title</CardTitle>
                    <CardDescription>Card Description</CardDescription>
                  </CardHeader>
                  <CardContent>
                    <p>This is the main content of the card.</p>
                  </CardContent>
                  <CardFooter>
                    <Button>Card Action</Button>
                  </CardFooter>
                </Card>
                <Card>
                  <CardHeader>
                    <CardTitle>Another Card</CardTitle>
                    <CardDescription>With different content</CardDescription>
                  </CardHeader>
                  <CardContent>
                    <p>Cards can contain various types of content and components.</p>
                  </CardContent>
                </Card>
              </div>
            </section>

            {/* Table Example */}
            <section>
              <h2 className="text-2xl font-semibold mb-4">Table</h2>
              <Table>
                <TableHeader>
                  <TableRow>
                    <TableHead>Name</TableHead>
                    <TableHead>Status</TableHead>
                    <TableHead>Role</TableHead>
                    <TableHead className="text-right">Actions</TableHead>
                  </TableRow>
                </TableHeader>
                <TableBody>
                  <TableRow>
                    <TableCell>Alice Johnson</TableCell>
                    <TableCell>Active</TableCell>
                    <TableCell>Developer</TableCell>
                    <TableCell className="text-right">
                      <Button size="sm">Edit</Button>
                    </TableCell>
                  </TableRow>
                  <TableRow>
                    <TableCell>Bob Smith</TableCell>
                    <TableCell>Inactive</TableCell>
                    <TableCell>Designer</TableCell>
                    <TableCell className="text-right">
                      <Button size="sm">Edit</Button>
                    </TableCell>
                  </TableRow>
                  <TableRow>
                    <TableCell>Carol Williams</TableCell>
                    <TableCell>Active</TableCell>
                    <TableCell>Manager</TableCell>
                    <TableCell className="text-right">
                      <Button size="sm">Edit</Button>
                    </TableCell>
                  </TableRow>
                </TableBody>
              </Table>
            </section>

            {/* Login Form Example */}
            <section>
              <h2 className="text-2xl font-semibold mb-4">Login Form</h2>
              <LoginForm />
            </section>

            {/* Registration Form Example */}
            <section>
              <h2 className="text-2xl font-semibold mb-4">Registration Form</h2>
              <RegistrationForm />
            </section>
            <section>
              <h2 className="text-2xl font-semibold mb-4">404 Page Test</h2>
              <Link href="/non-existent-page" className="text-blue-600 hover:underline">
                Test 404 Page
              </Link>
            </section>
          </div>
        </main>
      </div>
    </div>
  )
}

