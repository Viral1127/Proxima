import { Button } from "@/components/ui/button"
import Link from 'next/link'

export function HeroSection() {
  return (
    <div className="bg-gradient-to-r from-primary to-primary-foreground text-white py-20">
      <div className="container mx-auto text-center">
        <h1 className="text-5xl font-bold mb-6">Proxima: Elevate Your Project Management</h1>
        <p className="text-xl mb-8">Streamline workflows, boost productivity, and achieve your goals with Proxima.</p>
        <Button asChild size="lg" className="bg-white text-primary hover:bg-gray-100">
          <Link href="/dashboard">Get Started</Link>
        </Button>
      </div>
    </div>
  )
}

