(load "read_input.scm")


(define input (read-lines "input.txt"))

; Part 1
(define (solver lst)
  (if (null? (cdr lst))
      0
      (+ (if (< (car lst) (cadr lst)) 1 0)
         (solver (cdr lst)))))

(solver input)


; Part 2
(define (helper lst)
  (if (null? (cddr lst))
      '()
      (cons (+ (car lst) (cadr lst) (caddr lst))
            (helper (cdr lst)))))

<<<<<<< HEAD
(solver (helper input))
=======
(solver (helper input))
>>>>>>> 9d2ad360a642e1280e805cbb15b90e723feda4ba
